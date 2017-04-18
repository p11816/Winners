using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class MainForm : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private List<System.Windows.Forms.Button> buttonsForShape = new List<System.Windows.Forms.Button>();
        private AboutForm about;
        private ImageList imgForButtons = new ImageList();
        private Button activeButton = Button.None;
        private Color buttonColor;
        private Point delta;
        private int chosenElement = 0;
        private Point shapeCenter;
        private bool isDrawing = false;
        private bool isChosen = false;

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

            
        }

        private void InitializeButtonsForShape()
        {
            buttonsForShape.Add(Button1);
            buttonsForShape.Add(Button2);
            buttonsForShape.Add(Button3);
            buttonsForShape.Add(Button4);
            buttonsForShape.Add(Button5);
        }

        private void InitializeImagesForButtons()
        {
            imgForButtons.ImageSize = new Size(buttonsForShape[(int)(Button.Ellipse)].Size.Width - 13, buttonsForShape[(int)(Button.Ellipse)].Size.Height - 13);
            imgForButtons.Images.Add(Image.FromFile("../../circle.png"));
            buttonsForShape[(int)(Button.Ellipse)].ImageList = imgForButtons;
            buttonsForShape[(int)(Button.Ellipse)].ImageIndex = 0;
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
            g.Clear(SystemColors.Control);

            // рисуем все фигуры
            foreach (Shape s in this.shapes)
            {
                s.Paint(g);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            this.MainForm_Paint(sender, null);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(activeButton != Button.None)
            {
                shapeCenter = new Point(e.X, e.Y);
                shapes.Add(new Ellipse(e.X, e.Y, 0, 0));
                isDrawing = true;
            }

            else
            {
                delta = new Point(e.X, e.Y);
                
                foreach (Shape s in shapes)
                {
                    if (s.isInside(e.X, e.Y))
                    {
                        this.Text = "Выбран элемент №" + s.Id;
                        chosenElement = s.Id - 1;
                        isChosen = true;
                    }   
                }
            }
        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            if(activeButton != Button.None)
            {
                buttonsForShape[(int)(activeButton)].BackColor = buttonColor;
            }

            ((Control)sender).BackColor = Color.LightBlue;
            ChangeActiveButton(sender);
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
            if (e.KeyCode == Keys.Escape && activeButton != Button.None)
            {
                buttonsForShape[(int)(activeButton)].BackColor = buttonColor;
                activeButton = Button.None;
            }

            isChosen = false;
            Text = "";
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                Point center = new Point();
                center.X = shapeCenter.X <= e.X ? shapeCenter.X : e.X;
                center.Y = shapeCenter.Y <= e.Y ? shapeCenter.Y : e.Y;

                switch (activeButton)
                {
                    case Button.Ellipse:
                        shapes[shapes.Count - 1].point = new Point(center.X, center.Y);
                        ((Ellipse)shapes[shapes.Count - 1]).radiusV = Math.Abs(shapeCenter.X - e.X) / 2;
                        ((Ellipse)shapes[shapes.Count - 1]).radiusH = Math.Abs(shapeCenter.Y - e.Y) / 2;
                        break;
                    case Button.None:
                        break;
                    default:
                        break;
                }

                MainForm_Paint(null, null);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && isChosen && shapes[chosenElement].isInside(e.X, e.Y))
            {
                shapes[chosenElement].point = new Point(shapes[chosenElement].point.X - delta.X + e.X,
                    shapes[chosenElement].point.Y - delta.Y + e.Y);
                delta = new Point(e.X, e.Y);
                MainForm_Paint(null, null);
            }
        }
    }
}
