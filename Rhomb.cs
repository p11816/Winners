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
            int halfW = width / 2;
            int halfH = height / 2;
            g.DrawLine(pen, point.X + halfW, point.Y, point.X + width, point.Y + halfH);
            g.DrawLine(pen, point.X + width, point.Y + halfH, point.X + halfW, point.Y + height);
            g.DrawLine(pen, point.X + halfW, point.Y + height, point.X, point.Y + halfH);
            g.DrawLine(pen, point.X, point.Y + halfH, point.X + halfW, point.Y);
            System.Drawing.Point[] fillPoint = new System.Drawing.Point[1]; //точка заливки фигуры
            fillPoint[0].X = point.X + 1;
            fillPoint[0].Y = point.Y + halfH;
            g.FillClosedCurve(brush, fillPoint);
        }

        public override bool isInside(int X, int Y)
        {
          
            return false;
        }
    }
}
