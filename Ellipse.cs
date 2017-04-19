using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Painter
{
    class Ellipse : Shape
    {
        public int width;
        public int height;

        public Ellipse(int x, int y, int width, int height)
        {
            point = new System.Drawing.Point(x, y);
            this.width = width;
            this.height = height;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            g.FillEllipse(brush, point.X, point.Y, 2* width, 2* height);
            g.DrawEllipse(pen, point.X, point.Y, 2 * width, 2 * height);
        }
        public override bool isInside(int X, int Y)
        {
            bool result = this.isInside(X, Y, radiusV, radiusH);            
            return result;   
        }

        private bool isInside(int X, int Y, int radiusV, int radiusH)
        {
            bool result = false;
            Rectangle myEllipse = new Rectangle((int)point.X, (int)point.Y, width * 2, height * 2);
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(myEllipse);
            if (myPath.IsVisible(X, Y)) result = true;
            myPath.Dispose();

            return result;  
        }
        
        // попал ли курсор на границу
        //public override bool isOnTheBorder(int x, int y)
        //{
        //    bool result = false;
        //    int width = (int)pen.Width;

        //    //if (this.isInside(x + width, y + width, radiusV - 2*width, radiusH - 2*width))
        //    //{
        //    //    result = true;
        //    //}
        //    //else result = false;
        //    if (this.isInside(x, y))
        //    {

        //        if (this.isInside(x - width, y - width, radiusV - 2 * width, radiusH - 2 * width))
        //        {
        //            result = false;
        //        }
        //        else result = true;
        //    }
        //    if (result == true) MessageBox.Show("Попал на границу");
        //    return result;
        //} 

    }
}
