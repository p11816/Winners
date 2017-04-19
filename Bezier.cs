using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Painter
{
    class Bezier : Shape
    {
        public Bezier(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
        }

        public override void Paint(System.Drawing.Graphics g)
        {
            Point[] p = new Point[] { point, new Point(point.X + width, point.Y), new Point(point.X, point.Y + height), new Point(point.X + width, point.Y + height) };
            g.DrawBezier(pen, p[0], p[1], p[2], p[3]);
        }
    }
}
