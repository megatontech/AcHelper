using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace avatar
{
    public partial class Avatar : Form
    {
        public static bool isLogin = false;
        public static string userImgUrl = "http://cdn.aixifan.com/acfun-H5/public/images/original/avatar.jpg";
        public static string userName = "";

        public Avatar()
        {
            InitializeComponent();
            selectBtn.Enabled = false;
            submitBtn.Enabled = false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (isLogin)
            {
                //重新获取此用户头像
                JObject obj = JObject.Parse(WebUtil.userLoginString);
                if (obj != null)
                {
                    userImgUrl = (string)obj["img"];
                    userName = (string)obj["username"];
                }
                refreshBtn.Enabled = true;
                selectBtn.Enabled = true;
                submitBtn.Enabled = true;
                label1.Text = "ID:" + userName;
                label2.Text = "Status: Load OK";
            }
            else
            {
                label2.Text = "Status: Login first";
            }
            System.Net.WebRequest webreq = System.Net.WebRequest.Create(userImgUrl);
            System.Net.WebResponse webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileInfo(openFileDialog1.FileName).OpenRead();
            Byte[] buffer = new Byte[stream.Length];
            stream.Read(buffer, 0, Convert.ToInt32(stream.Length));
            if (buffer != null)
            {
                if (WebUtil.PostFile(buffer))
                {
                    label2.Text = "Status: upload OK";
                }
                else { label2.Text = "Status: upload no OK"; }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if ((openFileDialog1.FileName != ""))
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                label2.Text = "Status: wait for upload";
            }
        }
    }
}