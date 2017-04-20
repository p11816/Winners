namespace Painter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStripBottom = new System.Windows.Forms.StatusStrip();
            this.StatusStripTop = new System.Windows.Forms.StatusStrip();
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.WhigthLine = new System.Windows.Forms.TextBox();
            this.ColorBrashLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorBrash = new System.Windows.Forms.TextBox();
            this.ColorLine = new System.Windows.Forms.TextBox();
            this.ColorLineLabel = new System.Windows.Forms.Label();
            this.LineWhigth1 = new System.Windows.Forms.ComboBox();
            this.PicterLineWhigth = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicterLineWhigth)).BeginInit();
            this.SuspendLayout();
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(43, 18);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.AboutToolStripMenuItem.Text = "About";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.AutoSize = false;
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(830, 22);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStripMenuItem,
            this.OpenToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 18);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.SaveToolStripMenuItem.Text = "Save";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // StatusStripBottom
            // 
            this.StatusStripBottom.Location = new System.Drawing.Point(0, 509);
            this.StatusStripBottom.Name = "StatusStripBottom";
            this.StatusStripBottom.Size = new System.Drawing.Size(830, 22);
            this.StatusStripBottom.TabIndex = 1;
            this.StatusStripBottom.Text = "StatusStrip";
            // 
            // StatusStripTop
            // 
            this.StatusStripTop.AutoSize = false;
            this.StatusStripTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusStripTop.Location = new System.Drawing.Point(0, 22);
            this.StatusStripTop.Name = "StatusStripTop";
            this.StatusStripTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusStripTop.Size = new System.Drawing.Size(830, 68);
            this.StatusStripTop.SizingGrip = false;
            this.StatusStripTop.TabIndex = 3;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(2, 16);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(30, 30);
            this.Button1.TabIndex = 0;
            this.Button1.TabStop = false;
            this.Button1.Tag = "Circle";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.ShapeButton_Click);
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(2, 50);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(30, 30);
            this.Button2.TabIndex = 1;
            this.Button2.TabStop = false;
            this.Button2.Tag = "Circle";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(2, 84);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(30, 30);
            this.Button3.TabIndex = 2;
            this.Button3.TabStop = false;
            this.Button3.Tag = "Circle";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(2, 118);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(30, 30);
            this.Button4.TabIndex = 3;
            this.Button4.TabStop = false;
            this.Button4.Tag = "Circle";
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(2, 152);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(30, 30);
            this.Button5.TabIndex = 4;
            this.Button5.TabStop = false;
            this.Button5.Tag = "Circle";
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // LeftPanel
            // 
            this.LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPanel.Controls.Add(this.Button5);
            this.LeftPanel.Controls.Add(this.Button4);
            this.LeftPanel.Controls.Add(this.Button3);
            this.LeftPanel.Controls.Add(this.Button2);
            this.LeftPanel.Controls.Add(this.Button1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 90);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(36, 419);
            this.LeftPanel.TabIndex = 4;
            // 
            // WhigthLine
            // 
            this.WhigthLine.AccessibleName = "";
            this.WhigthLine.Enabled = false;
            this.WhigthLine.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.WhigthLine.Location = new System.Drawing.Point(59, 42);
            this.WhigthLine.Name = "WhigthLine";
            this.WhigthLine.ReadOnly = true;
            this.WhigthLine.Size = new System.Drawing.Size(100, 20);
            this.WhigthLine.TabIndex = 6;
            this.WhigthLine.Text = "Ширина линии";
            // 
            // ColorBrashLabel
            // 
            this.ColorBrashLabel.BackColor = System.Drawing.Color.White;
            this.ColorBrashLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorBrashLabel.Location = new System.Drawing.Point(587, 48);
            this.ColorBrashLabel.Name = "ColorBrashLabel";
            this.ColorBrashLabel.Size = new System.Drawing.Size(36, 32);
            this.ColorBrashLabel.TabIndex = 8;
            this.ColorBrashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ColorBrashLabel.Click += new System.EventHandler(this.ColorBrashLabel_Click);
            // 
            // ColorBrash
            // 
            this.ColorBrash.BackColor = System.Drawing.SystemColors.Control;
            this.ColorBrash.Enabled = false;
            this.ColorBrash.Location = new System.Drawing.Point(567, 25);
            this.ColorBrash.Name = "ColorBrash";
            this.ColorBrash.ReadOnly = true;
            this.ColorBrash.Size = new System.Drawing.Size(80, 20);
            this.ColorBrash.TabIndex = 9;
            this.ColorBrash.Text = "Цвет кисти";
            // 
            // ColorLine
            // 
            this.ColorLine.BackColor = System.Drawing.SystemColors.Control;
            this.ColorLine.Enabled = false;
            this.ColorLine.Location = new System.Drawing.Point(454, 25);
            this.ColorLine.Name = "ColorLine";
            this.ColorLine.ReadOnly = true;
            this.ColorLine.Size = new System.Drawing.Size(70, 20);
            this.ColorLine.TabIndex = 10;
            this.ColorLine.Text = "Цвет линии";
            // 
            // ColorLineLabel
            // 
            this.ColorLineLabel.BackColor = System.Drawing.Color.Black;
            this.ColorLineLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ColorLineLabel.Location = new System.Drawing.Point(470, 48);
            this.ColorLineLabel.Name = "ColorLineLabel";
            this.ColorLineLabel.Size = new System.Drawing.Size(36, 32);
            this.ColorLineLabel.TabIndex = 11;
            this.ColorLineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ColorLineLabel.Click += new System.EventHandler(this.ColorLineLabel_Click);
            // 
            // LineWhigth1
            // 
            this.LineWhigth1.FormattingEnabled = true;
            this.LineWhigth1.Location = new System.Drawing.Point(176, 41);
            this.LineWhigth1.MaxDropDownItems = 5;
            this.LineWhigth1.Name = "LineWhigth1";
            this.LineWhigth1.Size = new System.Drawing.Size(42, 21);
            this.LineWhigth1.TabIndex = 12;
            this.LineWhigth1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PicterLineWhigth
            // 
            this.PicterLineWhigth.Location = new System.Drawing.Point(235, 42);
            this.PicterLineWhigth.Name = "PicterLineWhigth";
            this.PicterLineWhigth.Size = new System.Drawing.Size(163, 28);
            this.PicterLineWhigth.TabIndex = 7;
            this.PicterLineWhigth.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(95, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "?";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button6_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 531);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.LineWhigth1);
            this.Controls.Add(this.ColorLineLabel);
            this.Controls.Add(this.ColorLine);
            this.Controls.Add(this.ColorBrash);
            this.Controls.Add(this.ColorBrashLabel);
            this.Controls.Add(this.PicterLineWhigth);
            this.Controls.Add(this.WhigthLine);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.StatusStripTop);
            this.Controls.Add(this.StatusStripBottom);
            this.Controls.Add(this.MenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseLeave += new System.EventHandler(this.MainForm_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicterLineWhigth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.StatusStrip StatusStripBottom;
        private System.Windows.Forms.StatusStrip StatusStripTop;
        
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Button Button5;
        private System.Windows.Forms.Button Button4;
        private System.Windows.Forms.Button Button3;
        private System.Windows.Forms.Button Button2;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.TextBox WhigthLine;
        private System.Windows.Forms.Label ColorBrashLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox ColorBrash;
        private System.Windows.Forms.TextBox ColorLine;
        private System.Windows.Forms.Label ColorLineLabel;
        private System.Windows.Forms.ComboBox LineWhigth1;
        private System.Windows.Forms.PictureBox PicterLineWhigth;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

