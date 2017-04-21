using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Painter
{
    class Ellipse : Shape
    {
        public Ellipse(int x, int y, int width, int height)
        {
            point = new System.Drawing.Point(x, y);
            this.width = width;
            this.height = height;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            g.FillEllipse(brush, point.X, point.Y, width, height);
            g.DrawEllipse(pen, point.X, point.Y, width, height);
        }
    }
}
