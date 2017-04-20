using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
    class TriangleRight : Shape
    {
        public int height;
        public int width;
        public Point[] apexTriangle;

        public TriangleRight(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            Point[] p = { new Point(point.X + width/2, point.Y), new Point(point.X, point.Y + height),
                new Point(point.X + width, point.Y + height) };
            apexTriangle = p;
            g.FillPolygon(brush, p);
            g.DrawPolygon(pen, p);
        }
    }
}
