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
        public Point[] vertex;                            // массив относительных координат вершин

        public Bezier(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
            vertex = new Point[4];
            getVertex();
        }

        private void getVertex()
        {
            vertex[0].X = 0;
            vertex[0].Y = 0;
            vertex[1].X = width;
            vertex[1].Y = 0;
            vertex[2].X = 0;
            vertex[2].Y = height;
            vertex[3].X = width;
            vertex[3].Y = height;
        }

        public override void Paint(System.Drawing.Graphics g)
        {
            getVertex();
            Point[] p = new Point[4];
            for (int i = 0; i < p.Length; ++i)
            {
                p[i] = new Point(point.X + vertex[i].X, point.Y + vertex[i].Y);
            } 
            g.DrawBezier(pen, p[0], p[1], p[2], p[3]);
        }
    }
}
