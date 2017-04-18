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
        public int radiusV;
        public int radiusH;

        public Ellipse(int x, int y, int radiusV, int radiusH)
        {
            point = new System.Drawing.Point(x, y);
            this.radiusV = radiusV;
            this.radiusH = radiusH;
        }
        public override void Paint(System.Drawing.Graphics g)
        {
            g.FillEllipse(brush, point.X, point.Y, 2* radiusV, 2* radiusH);
            g.DrawEllipse(pen, point.X, point.Y, 2 * radiusV, 2 * radiusH);
        }
        public override bool isInside(int X, int Y)
        {
            bool result = false;
            Rectangle myEllipse = new Rectangle((int)point.X, (int)point.Y, radiusV * 2, radiusH * 2);
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddEllipse(myEllipse);
            if (myPath.IsVisible(X, Y)) result = true;
            myPath.Dispose();
            
            return result;   
        }

        public override bool isOnTheBorder(int x, int y) { return true; } // попал ли курсор на границу

    }
}
