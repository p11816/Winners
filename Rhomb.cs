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
        public Point[] vertex;                            // массив относительных координат вершин
        public Rhomb(int x, int y, int height, int width)
        {
            point = new Point(x, y);
            this.height = height;
            this.width = width;
            vertex = new Point[4];
        }

        private void getVertex()
        {
            int halfW = width / 2;
            int halfH = height / 2;
            vertex[0].X = 0;
            vertex[0].Y = halfH;
            vertex[1].X = halfW;
            vertex[1].Y = 0;
            vertex[2].X = width;
            vertex[2].Y = halfH;
            vertex[3].X = halfW;
            vertex[3].Y = height;
        }

        public override void Paint(System.Drawing.Graphics g)
        {
            Point[] p = new Point[4];
            for (int i = 0; i < p.Length; ++i)
            {
                p[i] = new Point(point.X + vertex[i].X, point.Y + vertex[i].Y);
            }            
            g.FillPolygon(brush, p);
            g.DrawPolygon(pen, p);
        }
    }
}
