using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    class TriangleRight : Shape
    {
        public int height;
        public int width;
        public System.Drawing.Point[] apexTriangle;                 // координаты вершин треугольника

        public TriangleRight(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
            apexTriangle = new System.Drawing.Point[3];
        }

        private void inicializeApexTriangle()
        {
            apexTriangle[0].X = point.X;
            apexTriangle[0].Y = point.Y;
            apexTriangle[1].X = point.X + width;
            apexTriangle[1].Y = point.Y + height;
            apexTriangle[2].X = point.X + width;
            apexTriangle[2].Y = point.Y + height;
        }

        public override void Paint(System.Drawing.Graphics g)
        {
            g.DrawLine(pen, apexTriangle[0].X, apexTriangle[0].Y, apexTriangle[1].X, apexTriangle[1].Y);
            g.DrawLine(pen, apexTriangle[1].X, apexTriangle[1].Y, apexTriangle[2].X, apexTriangle[2].Y);
            g.DrawLine(pen, apexTriangle[3].X, apexTriangle[3].Y, apexTriangle[2].X, apexTriangle[2].Y);
            System.Drawing.Point[] fillPoint = new System.Drawing.Point[1]; //точка заливки фигуры
            fillPoint[0].X = point.X + 1; 
            fillPoint[0].Y = point.Y + height - 1;
            g.FillClosedCurve(brush, fillPoint);
        }

        public override bool isInside(int X, int Y)
        {
          
            return false;
        }
    }
}
