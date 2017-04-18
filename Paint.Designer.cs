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
            this.components = new System.ComponentModel.Container();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.StatusStripBottom = new System.Windows.Forms.StatusStrip();
            this.StatusStripTop = new System.Windows.Forms.StatusStrip();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.MenuStrip.SuspendLayout();
            this.LeftPanel.SuspendLayout();
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
            this.HelpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(830, 22);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
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
            this.StatusStripTop.Size = new System.Drawing.Size(830, 26);
            this.StatusStripTop.SizingGrip = false;
            this.StatusStripTop.TabIndex = 3;
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
            this.LeftPanel.Location = new System.Drawing.Point(0, 48);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(36, 461);
            this.LeftPanel.TabIndex = 4;
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
            // Timer
            // 
            this.Timer.Interval = 250;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 531);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.StatusStripTop);
            this.Controls.Add(this.StatusStripBottom);
            this.Controls.Add(this.MenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Timer Timer;
    }
}

