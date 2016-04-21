using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace HCover
{
    public partial class MainForm : WaitForm
    {
        private string url = @"http://h.acfun.tv/t/";
        private string savePath = Application.StartupPath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (!toggleSwitch2.IsOn)
            {
                Application.Exit();
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn)
            {
                url = @"http://h.acfun.tv/t/";
                url = url + textBox1.Text.Trim();
                getAllImg(url, textBox1.Text.Trim());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                toggleSwitch1.Enabled = true;
            }
        }

        private bool getAllImg(string url, string postNo)
        {
            bool isAllImgOk = false;
            Utils.SaveACWebFile savefile = new Utils.SaveACWebFile();
            Utils.ParseACPage parsepage = new Utils.ParseACPage();
            savePath = savePath + @"\" + postNo + @"\";
            Directory.CreateDirectory(savePath);
            int pageCount = parsepage.parseWebPageNo(url, postNo);
            for (int i = 1; i <= pageCount; i++)
            {
                //http://h.acfun.tv/t/4480216
                //http://h.acfun.tv/t/4480216?page=1
                richEditControl1.Text += "\n" + "No:" + postNo + "\n" + "第" + i + "页正在解析" + "\n";
                string[] tempArray = parsepage.parseWebPage(url + "?page=" + i, postNo);
                richEditControl1.Text += "该页链接数:" + tempArray.Length + "\n";

                if (i > 1)
                {
                    tempArray[0] = "";
                }
                if (tempArray.Length > 0)
                {
                    progressBarControl1.Properties.Minimum = 0;
                    progressBarControl1.Properties.Maximum = tempArray.Length;
                    progressBarControl1.Position = 0;
                    foreach (string temp in tempArray)
                    {
                        string fileName = savefile.SaveWebImage(temp, savePath);
                        progressBarControl1.PerformStep();
                        richEditControl1.Text += (fileName + "已经保存" + "\n");
                    }
                }
            }
            toggleSwitch1.IsOn = false; toggleSwitch1.Enabled = false;
            url = @"http://h.acfun.tv/t/";
            savePath = Application.StartupPath;
            textBox1.Text = "";
            return isAllImgOk;
        }
    }
}