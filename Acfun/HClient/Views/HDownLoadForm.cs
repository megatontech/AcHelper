using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraWaitForm;

namespace HClient
{
    public partial class HDownLoadForm : WaitForm
    {
        private string url = @"http://h.acfun.tv/t/";
        private string savePath = Application.StartupPath;
        private bool isCover = true;
        public HDownLoadForm()
        {
            InitializeComponent();
            if(toggleSwitch3.IsOn)
            {
                toggleSwitch2.Enabled = true;
            }
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (!toggleSwitch2.IsOn)
            {
                //Application.Exit();
                this.Close();
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (isCover)
            {
                Utils.SaveACWebFile savefile = new Utils.SaveACWebFile();

                savePath = savePath + @"\" + "cover" + @"\";
                Directory.CreateDirectory(savePath);
                progressBarControl1.Properties.Minimum = 0;
                progressBarControl1.Properties.Maximum = 999;
                progressBarControl1.Position = 0;
                for (int i = 0; i < 999; i++)
                {
                    string fileName = savefile.SaveWebImage(@"http://h.acfunwiki.org/cover.php", savePath, isCover);
                    progressBarControl1.PerformStep();
                    textBox2.Text += (fileName + "已经保存" + "\n");
                }

                //m_df = new DownloadForm(this);
                //DTaskData[] dts = new DTaskData[998];
                //for (int i = 0; i < dts.Length; ++i)
                //{
                //    dts[i] = new DTaskData();
                //    dts[i].Name = "Cover" + i.ToString();
                //    string url = @"http://h.acfunwiki.org/cover.php";
                //    ResourceLocation location = new ResourceLocation();
                //    string temp = savefile.GetImgPath(url, true);
                //    location.URL =( temp == "404" )? savefile.GetImgPath(url, true) : temp;
                //    location.Referer = @"http://h.acfunwiki.org/cover.php";
                //    dts[i].Location = location;
                //    dts[i].FileName = Application.StartupPath+@"\Cover\" + i.ToString();
                //    dts[i].Num = 4;
                //}

                //m_df.Show(dts, @"d:\dlist.config");


            }
            else 
            {
            if (toggleSwitch1.IsOn)
            {
                url = @"http://h.acfun.tv/t/";
                url = url + textBox1.Text.Trim();
                getAllImg(url, textBox1.Text.Trim());
            }
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
                textBox2.Text += "\n" + "No:" + postNo + "\n" + "第" + i + "页正在解析" + "\n";
                string[] tempArray = parsepage.parseWebPage(url + "?page=" + i, postNo);
                textBox2.Text += "该页链接数:" + tempArray.Length + "\n";

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
                        string fileName = savefile.SaveWebImage(temp, savePath,false);
                        progressBarControl1.PerformStep();
                        textBox2.Text += (fileName + "已经保存" + "\n");
                    }
                }
            }
            toggleSwitch1.IsOn = false; toggleSwitch1.Enabled = false;
            url = @"http://h.acfun.tv/t/";
            savePath = Application.StartupPath;
            textBox1.Text = "";
            return isAllImgOk;
        }

        private void toggleSwitch3_Toggled(object sender, EventArgs e)
        {
            if(toggleSwitch3.IsOn)
            {
                isCover = true;
                toggleSwitch2.Enabled = true;
            }else
            {
                
                isCover = false;
                toggleSwitch2.Enabled = false;
            }
        }
    }
}