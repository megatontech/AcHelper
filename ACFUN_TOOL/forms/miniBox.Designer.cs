namespace Article
{
    partial class miniBox
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
            this.linkLabel_push = new System.Windows.Forms.LinkLabel();
            this.linkLabel_call = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // linkLabel_push
            // 
            this.linkLabel_push.ActiveLinkColor = System.Drawing.Color.Lime;
            this.linkLabel_push.AutoSize = true;
            this.linkLabel_push.Dock = System.Windows.Forms.DockStyle.Left;
            this.linkLabel_push.Font = new System.Drawing.Font("幼圆", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_push.LinkColor = System.Drawing.Color.Lime;
            this.linkLabel_push.Location = new System.Drawing.Point(0, 0);
            this.linkLabel_push.Name = "linkLabel_push";
            this.linkLabel_push.Size = new System.Drawing.Size(31, 33);
            this.linkLabel_push.TabIndex = 0;
            this.linkLabel_push.TabStop = true;
            this.linkLabel_push.Text = "0";
            this.linkLabel_push.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_push_LinkClicked);
            // 
            // linkLabel_call
            // 
            this.linkLabel_call.AutoSize = true;
            this.linkLabel_call.Dock = System.Windows.Forms.DockStyle.Right;
            this.linkLabel_call.Font = new System.Drawing.Font("幼圆", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel_call.LinkColor = System.Drawing.Color.Red;
            this.linkLabel_call.Location = new System.Drawing.Point(79, 0);
            this.linkLabel_call.Name = "linkLabel_call";
            this.linkLabel_call.Size = new System.Drawing.Size(31, 33);
            this.linkLabel_call.TabIndex = 1;
            this.linkLabel_call.TabStop = true;
            this.linkLabel_call.Text = "0";
            this.linkLabel_call.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_call_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // miniBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(110, 95);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel_call);
            this.Controls.Add(this.linkLabel_push);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "miniBox";
            this.Opacity = 0.5D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "miniBox";
            this.TopMost = true;
            this.DoubleClick += new System.EventHandler(this.miniBox_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.miniBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.miniBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.miniBox_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel_push;
        private System.Windows.Forms.LinkLabel linkLabel_call;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}