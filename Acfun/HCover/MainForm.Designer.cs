namespace HCover
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.toggleSwitch2 = new DevExpress.XtraEditors.ToggleSwitch();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarControl1
            // 
            resources.ApplyResources(this.progressBarControl1, "progressBarControl1");
            this.progressBarControl1.Name = "progressBarControl1";
            // 
            // richEditControl1
            // 
            this.richEditControl1.AcceptsEscape = false;
            this.richEditControl1.AcceptsReturn = false;
            this.richEditControl1.AcceptsTab = false;
            this.richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            resources.ApplyResources(this.richEditControl1, "richEditControl1");
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Options.AutoCorrect.DetectUrls = false;
            this.richEditControl1.Options.AutoCorrect.ReplaceTextAsYouType = false;
            this.richEditControl1.Options.Fields.UseCurrentCultureDateTimeFormat = false;
            this.richEditControl1.Options.HorizontalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.richEditControl1.Options.MailMerge.KeepLastParagraph = false;
            this.richEditControl1.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            // 
            // toggleSwitch1
            // 
            resources.ApplyResources(this.toggleSwitch1, "toggleSwitch1");
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.OffText = resources.GetString("toggleSwitch1.Properties.OffText");
            this.toggleSwitch1.Properties.OnText = resources.GetString("toggleSwitch1.Properties.OnText");
            this.toggleSwitch1.Toggled += new System.EventHandler(this.toggleSwitch1_Toggled);
            // 
            // toggleSwitch2
            // 
            resources.ApplyResources(this.toggleSwitch2, "toggleSwitch2");
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.Properties.OffText = resources.GetString("toggleSwitch2.Properties.OffText");
            this.toggleSwitch2.Properties.OnText = resources.GetString("toggleSwitch2.Properties.OnText");
            this.toggleSwitch2.Toggled += new System.EventHandler(this.toggleSwitch2_Toggled);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toggleSwitch2);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.richEditControl1);
            this.Controls.Add(this.progressBarControl1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.ShowInTaskbar = true;
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch2;
        private System.Windows.Forms.TextBox textBox1;

    }
}
