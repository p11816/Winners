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
       
        public Point[] vertex;                            // массив относительных координат вершин

        public TriangleRight(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
            vertex = new Point[3];
            getVertex();
        }

        private void getVertex()
        {
            vertex[0].X = width / 2;
            vertex[0].Y = 0;
            vertex[1].X = 0;
            vertex[1].Y = height;
            vertex[2].X = width;
            vertex[2].Y = height;

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
