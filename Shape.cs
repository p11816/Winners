using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Painter
{
    abstract class Shape
    {
        public int Id { get; private set; }

        static private int lastId = 0;

        public static float Distance(Point a, Point b)
        {
            return (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        protected Shape()
        {
            point = new Point(0, 0);
            pen = new Pen(Color.Pink);
            pen.Width = 5;
            brush = new SolidBrush(Color.Lime);
            lastId++;
            Id = lastId;
        }
        public abstract void Paint(Graphics g);
        // положение
        public Point point;
        // контур
        public Pen pen;
        // заливка
        public Brush brush;

        public abstract bool isInside(int p1, int p2);

        public abstract bool isOnTheBorder(int x, int y); // попал ли курсор на границу
    }
}
