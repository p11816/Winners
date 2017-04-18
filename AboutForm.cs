using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            LogoPictureBox.Size = new Size(ClientSize.Width - 40, LogoPictureBox.Height);
            LogoPictureBox.Left = ClientRectangle.Left + 20;
            label1.Left = (ClientSize.Width - label1.Width) / 2;
            label2.Left = (ClientSize.Width - label2.Width) / 2;
        }
    }
}
