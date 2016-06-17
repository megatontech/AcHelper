using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Article.baseUtils;

namespace Article.forms
{
    public partial class userReg : Form
    {
        private WebUtil webutil = new WebUtil();

        [DllImport("AspriseOCR.dll", EntryPoint = "OCR", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OCR(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpart", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr OCRpart(string file, int type, int startX, int startY, int width, int height);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRBarCodes", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr OCRBarCodes(string file, int type);

        [DllImport("AspriseOCR.dll", EntryPoint = "OCRpartBarCodes", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr OCRpartBarCodes(string file, int type, int startX, int startY, int width, int height);

        public userReg()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            BindControl();
        }

        public userReg(string username, string mailbox)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            this.textBox_mail.Text = mailbox;
            this.textBox_name.Text = username;
            BindControl();
        }

        public void BindData()
        {
            this.pictureBox1.Image = webutil.getCaptcha();
            if (this.pictureBox1.Image == null)
            {
                this.pictureBox1.Image = webutil.getCaptcha();
            }
            string s = "";
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username from regname where isreg = 0 and isused = 0 limit 1;";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            this.textBox_name.Text = dt.Rows[0]["username"].ToString();
            string id = Guid.NewGuid().ToString();
            pictureBox1.Image.Save(System.Environment.CurrentDirectory + "\\Image\\" + id + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string temp = Marshal.PtrToStringAnsi(OCRpart(System.Environment.CurrentDirectory + "\\Image\\" + id + ".jpg", -1, 0, 0, 110, 50));
            string newStr = "";
            for (int i = 0; i < temp.Length; i++)
            {
                int tmp = (int)temp[i];
                if ((tmp >= 65 && tmp <= 90) || (tmp >= 97 && tmp <= 122))
                {
                    newStr += temp[i];
                }
            }
            this.textBox_captcha.Text = newStr;
            if (newStr.Length != 4)
            {
                BindControl();
            }
        }

        public void BindControl()
        {
            Thread th = new Thread(new ThreadStart(BindData));
            th.Start();
        }

        /// <summary>
        /// reg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string s = webutil.regNewUser(textBox_mail.Text.Trim(), textBox_name.Text.Trim(), textBox_pwd.Text.Trim(), textBox_invite.Text, textBox_captcha.Text.Trim(), webutil.cookiec);
            if (!s.Contains("false"))
            {
                string sqlInsert = "insert into user (username,userpassword,mailbox) values('" + textBox_name.Text + "','" + textBox_pwd.Text + "','" + textBox_mail.Text + "');";
                SqlLiteConn conn = new SqlLiteConn();
                string sqlUpdate = " update regname set isreg = 1 , isused = 1 where username = '" + textBox_name.Text + "'";
                conn.ExecuteScalar(sqlUpdate, null);
                conn.ExecuteScalar(sqlInsert, null);
                MessageBox.Show(s);
                BindControl();
                this.textBox_mail.Text = "";
            }
            else
            {
                MessageBox.Show(s);
            }
        }

        /// <summary>
        /// captcha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            BindControl();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sqlUpdate = " update regname set isreg = 1 , isused = 1 where username = '" + textBox_name.Text + "'";
            conn.ExecuteScalar(sqlUpdate, null);
            string sql = "select username from regname where isreg = 0 and isused = 0 limit 1;";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            this.textBox_name.Text = dt.Rows[0]["username"].ToString();
        }
    }
}