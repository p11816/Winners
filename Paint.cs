using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private enum FrameEdge
        {
            Top,
            Left,
            Right,
            Bottom,
            None
        }

        private SaveFileDialog seveFileDialog;
        private OpenFileDialog openFileDialog;

        private void InitializeSaveFileDialog()
        {
            seveFileDialog = new SaveFileDialog();
            seveFileDialog.Filter = "Xml documents |*.xml";
            seveFileDialog.FileName = "NewFile.xml";
            seveFileDialog.FileOk += seveFileDialog_FileOk;
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
            buttonColor = Button5.BackColor;

            InitializeSaveFileDialog();
            InitializeOpenFileDialog();            
            
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
            buttonsForShape[(int)(Button.Ellipse)].ImageList = imgForButtons;
            buttonsForShape[(int)(Button.Ellipse)].ImageIndex = 0;
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
            Graphics g = this.CreateGraphics();
            g.Clear(SystemColors.Control); // задаем цвет заливки холста

            // рисуем все фигуры
            foreach (Shape s in this.shapes)
            {
                s.Paint(g);
            }

            if (isChosen)
            {
                Pen pen = new Pen(Color.Black);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pen.Width = 5;
                g.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.White)), frames[chosenElement]);
                g.DrawRectangle(pen, frames[chosenElement]);
        }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.MainForm_Paint(sender, null);
        }

        private FrameEdge IsOnRectacleBorder(int x, int y)
        {
            Rectangle rect = frames[chosenElement];
            FrameEdge result = FrameEdge.None;

            
            if(y >= rect.Y - 5 && y <= rect.Y + 5 && x <= rect.X + rect.Width && x >= rect.X)
            {
                Cursor = Cursors.SizeNS;
                result = FrameEdge.Top;
            }

            else if(y <= rect.Y + rect.Height + 5 && y >= rect.Y + rect.Height - 5 && x <= rect.X + rect.Width && x >= rect.X)
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
                shapes.Add(new Ellipse(e.X, e.Y, 0, 0));
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
                    if (s.isInside(e.X, e.Y))
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
            if(e is MouseEventArgs)
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
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape && activeButton == Button.None)
            {
                isChosen = false;
                MainForm_Paint(null, null);
            }

            if (e.KeyCode == Keys.Escape && activeButton != Button.None)
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

                switch (activeButton)
                {
                    case Button.Ellipse:
                        shapes[shapes.Count - 1].point = new Point(center.X, center.Y);
                        width = ((Ellipse)shapes[shapes.Count - 1]).width = Math.Abs(shapeCenter.X - e.X) / 2;
                        height = ((Ellipse)shapes[shapes.Count - 1]).height = Math.Abs(shapeCenter.Y - e.Y) / 2;
                        frames[frames.Count - 1] = new Rectangle(center.X, center.Y, width*2, height*2);
                        break;
                    case Button.None:
                        break;
                    default:
                        break;
                }

                MainForm_Paint(null, null);
            }

            else if (isResizing) isResizing = false;
        }

       
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Text = Convert.ToString(Cursor.Position.X - 36);
            textBox2.Text = Convert.ToString(Cursor.Position.Y - 113);
            if (isResizing && e.Button == MouseButtons.Left)
            {
               
                    int width = 0;
                    int height = 0;

                    switch (edge)
                    {
                        case FrameEdge.Top:
                            delta = new Point(0, -(e.Y - frames[chosenElement].Top));
                            shapes[chosenElement].point.Y = e.Y;
                            break;
                        case FrameEdge.Left:
                            delta = new Point(-(e.X - frames[chosenElement].X), 0);
                            shapes[chosenElement].point.X = e.X;
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

                    height = ((Ellipse)shapes[chosenElement]).height += delta.Y;
                    width = ((Ellipse)shapes[chosenElement]).width += delta.X;
                    frames[chosenElement] = new Rectangle(shapes[chosenElement].point.X, shapes[chosenElement].point.Y,
                        width * 2, height * 2);
                    MainForm_Paint(null, null);
            }

            // условие при котором фигуру нужно перетаскивать
            else if (e.Button == MouseButtons.Left && isChosen && frames[chosenElement].Contains(new Point(e.X, e.Y)))
            {
                shapes[chosenElement].point = new Point(shapes[chosenElement].point.X - delta.X + e.X,
                    shapes[chosenElement].point.Y - delta.Y + e.Y);
                delta = new Point(e.X, e.Y);
                frames[chosenElement] = new Rectangle(shapes[chosenElement].point.X, shapes[chosenElement].point.Y,
                    frames[chosenElement].Width, frames[chosenElement].Height);
                MainForm_Paint(null, null);
            }

            else if (isChosen && IsOnRectacleBorder(e.X, e.Y) != FrameEdge.None) { }


            else Cursor = Cursors.Arrow;
        }


        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            seveFileDialog.ShowDialog();
        }

        void seveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string name = seveFileDialog.FileName;
            try
            {
                using (StreamWriter file = new StreamWriter(name))
                {
                    //if()
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                seveFileDialog.FileName = "NewFile.xml";
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }
        void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var file = openFileDialog.OpenFile();
            //throw new NotImplementedException();
        }

      
        private void ColorBrashLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorBrashLabel.BackColor = colorDialog1.Color;
            ColorBrashLabel.Tag = colorDialog1.Color;
        }

        private void ColorLineLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorLineLabel.BackColor = colorDialog1.Color;
            ColorLineLabel.Tag = colorDialog1.Color;
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineWhigth1.Tag = Convert.ToInt32(LineWhigth1.Items[LineWhigth1.SelectedIndex]);
            string pathPict = "..\\..\\Line";
            pathPict += LineWhigth1.Tag + ".jpg";
            PicterLineWhigth.Image = Image.FromFile(pathPict);
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Разработчики: \n\nЗайцев Владимир \nШибалович Иван \nВысоких Дмитрий \nАладьин Андрей");
        }

    }
}
