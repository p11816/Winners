﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace Painter
{
    public partial class MainForm : Form
    {
        private List<Shape> shapes = new List<Shape>(); // фигуры
        private List<Rectangle> frames = new List<Rectangle>(); // рамки для выделенных объектов
        private List<System.Windows.Forms.Button> buttonsForShape = new List<System.Windows.Forms.Button>();
        private AboutForm about;
        private ImageList imgForButtons = new ImageList();
        private Button activeButton = Button.None;
        private Color buttonColor;
        private Point delta;
        private int chosenElement = 0;
        private Point shapeCenter; // начальная точка отрисовки фигур
        private bool isDrawing = false; // рисование началось, ЛКМ зажата и курсор двигается
        private bool isChosen = false; // выделен элемент
        private bool isResizing = false; // растягивание фигуры
        private FrameEdge edge = FrameEdge.None;
        private Graphics graphics; 
        private bool isZooming = false;
        private bool isDecreasing = false;
        private float coefficient = 1.0f;

        private enum FrameEdge
        {
            Top,
            Left,
            Right,
            Bottom,
            None
        }

        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;

        private void InitializeSaveFileDialog()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Xml documents |*.xml";
            saveFileDialog.FileName = "NewFile.xml";
            saveFileDialog.FileOk += saveFileDialog_FileOk;
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml documents |*.xml";
            openFileDialog.FileOk += openFileDialog_FileOk;
        }

        private enum Button
        {
            Ellipse,
            Rectangle,
            Triangle,
            Rhomb,
            Bezier,
            None
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeButtonsForShape();
            InitializeImagesForButtons();
            WindowState = FormWindowState.Maximized;
            buttonsForShape[(int)(Button.Ellipse)].ImageList = imgForButtons;
            buttonsForShape[(int)(Button.Ellipse)].ImageIndex = 0;
            InitializeSaveFileDialog();
            InitializeOpenFileDialog();
            graphics = this.CreateGraphics();
            graphics.Clear(SystemColors.Control);
        }

        private void InitializeButtonsForShape()
        {
            buttonsForShape.Add(Button1);
            buttonsForShape.Add(Button2);
            buttonsForShape.Add(Button3);
            buttonsForShape.Add(Button4);
            buttonsForShape.Add(Button5);
            LineWhigth1.Items.Add("3");
            LineWhigth1.Items.Add("5");
            LineWhigth1.Items.Add("7");
            LineWhigth1.Items.Add("9");
            LineWhigth1.Items.Add("11");
            LineWhigth1.SelectedIndex = 0;
        }

        private void InitializeImagesForButtons()
        {
            imgForButtons.ImageSize = new Size(buttonsForShape[(int)(Button.Ellipse)].Size.Width - 13, buttonsForShape[(int)(Button.Ellipse)].Size.Height - 13);
            imgForButtons.Images.Add(Image.FromFile("../../circle.png"));
            imgForButtons.Images.Add(Image.FromFile("../../rectangle.png"));
            imgForButtons.Images.Add(Image.FromFile("../../triangle.png"));
            imgForButtons.Images.Add(Image.FromFile("../../rhomb.png"));
            imgForButtons.Images.Add(Image.FromFile("../../bezier.png"));
            buttonsForShape[(int)(Button.Rhomb)].ImageList = buttonsForShape[(int)(Button.Triangle)].ImageList = buttonsForShape[(int)(Button.Rectangle)].ImageList
                = buttonsForShape[(int)(Button.Ellipse)].ImageList = buttonsForShape[(int)(Button.Bezier)].ImageList = imgForButtons;
            buttonsForShape[(int)(Button.Ellipse)].ImageIndex = 0;
            buttonsForShape[(int)(Button.Rectangle)].ImageIndex = 1;
            buttonsForShape[(int)(Button.Triangle)].ImageIndex = 2;
            buttonsForShape[(int)(Button.Rhomb)].ImageIndex = 3;
            buttonsForShape[(int)(Button.Bezier)].ImageIndex = 4;
            PicterLineWhigth.Image = Image.FromFile("..\\..\\Line3.jpg");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = new AboutForm();
            about.Show();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // GDI+

            // DirectDraw, OpenGL, Vulcan

            // game engines: ioquake, unity, SDL...

            // создаём холст - canvas

            BufferedGraphicsContext currentContext;
            BufferedGraphics buffer;
            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with Form1, and with 
            // dimensions the same size as the drawing surface of Form1.
            buffer = currentContext.Allocate(this.CreateGraphics(),
               this.DisplayRectangle);
            buffer.Graphics.Clear(SystemColors.Control);
            

            if(isZooming || isDecreasing)
            {
                if (isZooming) coefficient += coefficient == 3.0f ? 0f : 0.2f;
                else coefficient -= coefficient == -3.0f ? 0f : 0.2f;

                buffer.Graphics.ScaleTransform(coefficient, coefficient, System.Drawing.Drawing2D.MatrixOrder.Append);  // then scale
                isZooming = false;
                isDecreasing = false;
            }
            
            
            // рисуем все фигуры
            foreach (Shape s in this.shapes) { s.Paint(buffer.Graphics); }

            if (isChosen)
            {
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pen.Width = 5;
                buffer.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.White)), frames[chosenElement]);
                buffer.Graphics.DrawRectangle(pen, frames[chosenElement]);
            }

            // Renders the contents of the buffer to the specified drawing surface.
            buffer.Render(graphics);
            buffer.Dispose();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.MainForm_Paint(sender, null);
        }

        private FrameEdge IsOnRectacleBorder(int x, int y)
        {
            Rectangle rect = frames[chosenElement];
            FrameEdge result = FrameEdge.None;


            if (y >= rect.Y - 5 && y <= rect.Y + 5 && x <= rect.X + rect.Width && x >= rect.X)
            {
                Cursor = Cursors.SizeNS;
                result = FrameEdge.Top;
            }

            else if (y <= rect.Y + rect.Height + 5 && y >= rect.Y + rect.Height - 5 && x <= rect.X + rect.Width && x >= rect.X)
            {
                Cursor = Cursors.SizeNS;
                result = FrameEdge.Bottom;
            }


            else if (x >= rect.X - 5 && x <= rect.X + 5 && y <= rect.Y + rect.Height && y >= rect.Y)
            {
                Cursor = Cursors.SizeWE;
                result = FrameEdge.Left;
            }

            else if (x >= rect.X + rect.Width - 5 && x <= rect.X + rect.Width + 5 && y <= rect.Y + rect.Height && y >= rect.Y)
            {
                Cursor = Cursors.SizeWE;
                result = FrameEdge.Right;
            }

            return result;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeButton != Button.None)
            {
                shapeCenter = new Point(e.X, e.Y);


                switch (activeButton)
                {
                    case Button.Ellipse:
                        shapes.Add(new Ellipse(e.X, e.Y, 0, 0));
                        break;
                    case Button.Rectangle:
                        shapes.Add(new Rect(e.X, e.Y, 0, 0));
                        break;
                    case Button.Triangle:
                        shapes.Add(new TriangleRight(e.X, e.Y, 0, 0));
                        break;
                    case Button.Rhomb:
                        shapes.Add(new Rhomb(e.X, e.Y, 0, 0));
                        break;
                    case Button.Bezier:
                        shapes.Add(new Bezier(e.X, e.Y, 0, 0));
                        break;
                }

                shapes[shapes.Count - 1].pen.Color = ColorLineLabel.BackColor;
                shapes[shapes.Count - 1].pen.Width = Convert.ToInt32(LineWhigth1.GetItemText(this.LineWhigth1.SelectedItem));
                ((SolidBrush)(shapes[shapes.Count - 1].brush)).Color = ColorBrashLabel.BackColor;
                frames.Add(new Rectangle(e.X, e.Y, 0, 0));
                isDrawing = true;
            }

            else if (isChosen && (edge = IsOnRectacleBorder(e.X, e.Y)) != FrameEdge.None) { isResizing = true; }

            else // выделяем фигуру
            {
                delta = new Point(e.X, e.Y);
                int index = -1;

                foreach (Shape s in shapes)
                {
                    index++;
                    if (frames[index].Contains(e.X, e.Y))
                    {
                        chosenElement = index;
                        isChosen = true;
                    }
                }

                if (isChosen) MainForm_Paint(null, null);
            }
        }

        private void ShapeButton_Click(object sender, EventArgs e) // нажатие на кнопку с фигурой
        {
            if (e is MouseEventArgs)
            {
                if (activeButton != Button.None)
                {
                    buttonsForShape[(int)(activeButton)].BackColor = buttonColor;
                }
                isChosen = false;
                ((Control)sender).BackColor = Color.LightBlue;
                ChangeActiveButton(sender);
            }
        }

        private void ChangeActiveButton(object sender)
        {
            switch ((string)((Control)sender).Tag)
            {
                case "Circle":
                    activeButton = Button.Ellipse;
                    break;
                case "Triangle":
                    activeButton = Button.Triangle;
                    break;
                case "Rhomb":
                    activeButton = Button.Rhomb;
                    break;
                case "Rectangle":
                    activeButton = Button.Rectangle;
                    break;
                case "Bezier":
                    activeButton = Button.Bezier;
                    break;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Add)
            {
                isZooming = true;
                MainForm_Paint(null, null);
            }

            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Subtract)
            {
                isDecreasing = true;
                MainForm_Paint(null, null);
            }


            else if (e.KeyCode == Keys.Escape && activeButton == Button.None)
            {
                isChosen = false;
                MainForm_Paint(null, null);
            }

            else if (e.KeyCode == Keys.Escape && activeButton != Button.None)
            {
                buttonsForShape[(int)(activeButton)].BackColor = buttonColor;
                activeButton = Button.None;
                isChosen = false;
                MainForm_Paint(null, null);
            }

            else if (e.KeyCode == Keys.Delete && isChosen)
            {
                shapes.RemoveAt(chosenElement);
                frames.RemoveAt(chosenElement);
                isChosen = false;
                MainForm_Paint(null, null);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                int width = 0;
                int height = 0;
                Point center = new Point();
                center.X = shapeCenter.X <= e.X ? shapeCenter.X : e.X;
                center.Y = shapeCenter.Y <= e.Y ? shapeCenter.Y : e.Y;
                shapes[shapes.Count - 1].point = new Point(center.X, center.Y);
                width = shapes[shapes.Count - 1].width = Math.Abs(shapeCenter.X - e.X);
                height = shapes[shapes.Count - 1].height = Math.Abs(shapeCenter.Y - e.Y);
                frames[frames.Count - 1] = new Rectangle(center.X - 20, center.Y - 20, width + 40, height + 40);
                MainForm_Paint(null, null);
            }

            else if (isResizing) isResizing = false;
        }

       
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= 36 && e.Location.Y >= 90)
            {
                label1.Text = "X: " + Convert.ToString(e.Location.X - 36);
                label2.Text = "Y: " + Convert.ToString(e.Location.Y - 90);
            }

            if (isResizing && e.Button == MouseButtons.Left)
            {

                int width = 0;
                int height = 0;

                switch (edge)
                {
                    case FrameEdge.Top:
                        delta = new Point(0, -(e.Y - frames[chosenElement].Top));
                        shapes[chosenElement].point.Y = e.Y + 20;
                        break;
                    case FrameEdge.Left:
                        delta = new Point(-(e.X - frames[chosenElement].X), 0);
                        shapes[chosenElement].point.X = e.X + 20;
                        break;
                    case FrameEdge.Right:
                        delta = new Point(e.X - (frames[chosenElement].Right), 0);
                        shapes[chosenElement].point.X += delta.X > 0 ? (-delta.X) : Math.Abs(delta.X);
                        break;
                    case FrameEdge.Bottom:
                        delta = new Point(0, e.Y - frames[chosenElement].Bottom);
                        shapes[chosenElement].point.Y += delta.Y > 0 ? (-delta.Y) : Math.Abs(delta.Y);
                        break;
                }

                height = shapes[chosenElement].height += 2 * delta.Y;
                width = shapes[chosenElement].width += 2 * delta.X;
                frames[chosenElement] = new Rectangle(shapes[chosenElement].point.X - 20, shapes[chosenElement].point.Y - 20,
                   width + 40, height + 40);
                MainForm_Paint(null, null);
            }

            else if(isDrawing)
            {
                int width = Math.Abs(e.X - shapeCenter.X);
                int height = Math.Abs(e.Y - shapeCenter.Y);

                int x = e.X < shapeCenter.X ? e.X : shapeCenter.X;
                int y = e.Y < shapeCenter.Y ? e.Y : shapeCenter.Y;

                shapes[shapes.Count - 1].point.X = x;
                shapes[shapes.Count - 1].point.Y = y;
                shapes[shapes.Count - 1].width = width;
                shapes[shapes.Count - 1].height = height;
                MainForm_Paint(null, null);
            }

            // условие при котором фигуру нужно перетаскивать
            else if (e.Button == MouseButtons.Left && isChosen && frames[chosenElement].Contains(new Point(e.X, e.Y)))
            {
                shapes[chosenElement].point = new Point(shapes[chosenElement].point.X - delta.X + e.X,
                    shapes[chosenElement].point.Y - delta.Y + e.Y);
                delta = new Point(e.X, e.Y);
                frames[chosenElement] = new Rectangle(shapes[chosenElement].point.X - 20, shapes[chosenElement].point.Y - 20,
                    frames[chosenElement].Width, frames[chosenElement].Height);
                MainForm_Paint(null, null);
            }

            else if (isChosen && IsOnRectacleBorder(e.X, e.Y) != FrameEdge.None) { }

            else Cursor = Cursors.Arrow;
        }


        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)        // вызов меню "Сохранить"
        {
            saveFileDialog.ShowDialog();
        }

        void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string nameFile = saveFileDialog.FileName;                                  // полный путь к файлу
            try
            {
                XDocument xdoc = new XDocument();                                   // создаём документ
                XElement homeElem = new XElement("svg");                            // создаём корневой элемент(тэг)
                foreach(var it in shapes)
                {
                    string elemName = "";                                           // имя вложенного элемента
                    List<XAttribute> att = new List<XAttribute>();                  // коллекция атрибутов вложенного элемента
                   
                    if(it is Ellipse)
                    {
                        elemName = "ellipse";
                        Ellipse elem = it as Ellipse;
                        att.Add(new XAttribute("cx", elem.point.X + elem.width / 2));
                        att.Add(new XAttribute("cy", elem.point.Y + elem.height / 2));
                        att.Add(new XAttribute("rx", elem.width / 2));
                        att.Add(new XAttribute("ry", elem.height / 2));
                        att.Add(new XAttribute("style", getAttriburStyle(elem.pen, elem.brush)));
                    }
                    else
                    {
                        att.Add(new XAttribute("x", it.point.X));
                        att.Add(new XAttribute("y", it.point.Y));
                        att.Add(new XAttribute("width", it.width));
                        att.Add(new XAttribute("height", it.height));
                        if (it is Rect)
                        {
                            elemName = "rect";
                            Rect elem = it as Rect;
                            att.Add(new XAttribute("style", getAttriburStyle(elem.pen, elem.brush)));
                        }
                        else if (it is Rhomb)
                        {
                            elemName = "polygon";
                            Rhomb elem = it as Rhomb;
                            string attributeValue = "";
                            for (int i = 0; i < elem.vertex.Length; ++i)
                            {
                                attributeValue += (elem.point.X + elem.vertex[i].X) + "," + (elem.point.Y + elem.vertex[i].Y) + " ";
                            }
                            att.Add(new XAttribute("points", attributeValue));
                            att.Add(new XAttribute("style", getAttriburStyle(elem.pen, elem.brush)));
                        }
                        else if (it is TriangleRight)
                        {
                            elemName = "polygon";
                            TriangleRight elem = it as TriangleRight;

                            string attributeValue = "";
                            for (int i = 0; i < elem.vertex.Length; ++i)
                            {
                                attributeValue += (elem.point.X + elem.vertex[i].X) + "," + (elem.point.Y + elem.vertex[i].Y) + " ";
                            }
                            att.Add(new XAttribute("points", attributeValue));
                            att.Add(new XAttribute("style", getAttriburStyle(elem.pen, elem.brush)));
                        }
                        else if (it is Bezier)
                        {
                            elemName = "path";
                            Bezier elem = it as Bezier;

                            string attributeValue = "M" + (elem.point.X + elem.vertex[0].X) + "," + (elem.point.Y + elem.vertex[0].Y) + " c";
                            for (int i = 1; i < elem.vertex.Length; ++i)
                            {
                                attributeValue += elem.vertex[i].X + "," + elem.vertex[i].Y + " ";
                            }
                            att.Add(new XAttribute("d", attributeValue));
                            att.Add(new XAttribute("style", getAttriburStyle(elem.pen, new SolidBrush(Color.FromArgb(0,0,0,0)))));
                        }
                    }
                    homeElem.Add(new XElement(elemName, att));                      // добавляем вложенный элемент в корневой
                }
                xdoc.Add(homeElem);                                                 // добавляем корневой элемент со всеми его вложенными элементами в документ
                xdoc.Save(nameFile);                                                // сохраняем файл
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                saveFileDialog.FileName = "NewFile.xml";
            }
        }

        private string getAttriburStyle(Pen pen, Brush brush)
        {
            SolidBrush br = brush as SolidBrush;
            string s = "fill:";
            s += (br.Color.A != 0 ? ("rgb(" + br.Color.R + "," + br.Color.G + "," + br.Color.B + ");") : ("none;"));
            
            s += "strocke-width:" + pen.Width + ";";
            s += "stroke:rgb(" + pen.Color.R + "," + pen.Color.G + "," + pen.Color.B + ")";
            return s;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)        // вызов меню "Открыть"
        {
            openFileDialog.ShowDialog();
        }
        void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var file = openFileDialog.OpenFile();
        }


        private void ColorBrashLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorBrashLabel.BackColor = colorDialog1.Color;
            ColorBrashLabel.Tag = colorDialog1.Color;

            if(isChosen)
            {
                ((SolidBrush)shapes[chosenElement].brush).Color = ColorBrashLabel.BackColor;
                MainForm_Paint(null, null);
            }
        }

        private void ColorLineLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorLineLabel.BackColor = colorDialog1.Color;
            ColorLineLabel.Tag = colorDialog1.Color;
            
            if(isChosen)
            {
                shapes[chosenElement].pen.Color = ColorLineLabel.BackColor;
                MainForm_Paint(null, null);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineWhigth1.Tag = Convert.ToInt32(LineWhigth1.Items[LineWhigth1.SelectedIndex]);
            string pathPict = "..\\..\\Line";
            pathPict += LineWhigth1.Tag + ".jpg";
            PicterLineWhigth.Image = Image.FromFile(pathPict);

            if (isChosen)
            {
                shapes[chosenElement].pen.Width = Convert.ToInt32(LineWhigth1.GetItemText(this.LineWhigth1.SelectedItem));
                MainForm_Paint(null, null);
            }
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Temlead: \nЗайцев Владимир \n\nProgers: \nШибалович Иван \nВысоких Дмитрий \nАладьин Андрей");
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
        }
    }
}
