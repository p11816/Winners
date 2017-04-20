using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Painter
{
    class Rhomb : Shape 
    {
        public Rhomb(int x, int y, int height, int width)
        {
            point = new Point(x, y);
            this.height = height;
            this.width = width;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            int halfW = width / 2;
            int halfH = height / 2;
            Point[] p = { new Point(point.X, point.Y + halfH), new Point(point.X + halfW, point.Y),
                new Point(point.X + width, point.Y + halfH), new Point(point.X + halfW, point.Y + height) };
            g.FillPolygon(brush, p);
            g.DrawPolygon(pen, p);
        }
    }
}
