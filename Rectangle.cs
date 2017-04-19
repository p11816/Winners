using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    class Rect : Shape
    {
        public int height;
        public int width;

        public Rect(int x, int y, int height, int width)
        {
            point = new System.Drawing.Point(x, y);
            this.height = height;
            this.width = width;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            g.FillRectangle(brush, point.X, point.Y, width, height);
            g.DrawRectangle(pen, point.X, point.Y, width, height);
        }

        public override bool isInside(int X, int Y)
        {
            if(X >= point.X && X <= point.X + width && Y >= point.Y && Y <= point.Y + height)
            {
                return true;
            }
            return false;
        }

    }
}
