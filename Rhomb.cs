using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    class Rhomb : Shape 
    {
         public int height;
        public int width;

        public Rhomb(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            g.DrawLine(pen, point.X, point.Y, point.X + width, point.Y + height);
            g.DrawLine(pen, point.X, point.Y, point.X, point.Y + height);
            g.DrawLine(pen, point.X + height, point.Y, point.X + width, point.Y + height);
            System.Drawing.Point[] fillPoint = new System.Drawing.Point[1]; //точка заливки фигуры
            fillPoint[0].X = point.X + 1; 
            fillPoint[0].Y = point.Y + 1;
            g.FillClosedCurve(brush, fillPoint);
        }

        public override bool isInside(int X, int Y)
        {
          
            return false;
        }
    }
}
