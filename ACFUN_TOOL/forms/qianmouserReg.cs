using System;
using System.Text;
using System.Web;
using System.Windows.Forms;
using Article.baseUtils;
using Newtonsoft.Json.Linq;

namespace Article.forms
{
    public partial class qianmouserReg : Form
    {
        private WebUtil webutil = new WebUtil();
        private string mail = "";
        private string mid = "";

        public qianmouserReg()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            button1.Enabled = false;
            //button4.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
        }

        /// <summary>
        /// reg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string mail = textBox_mail.Text.Trim();
            webutil.regQianmo(mail, "153037");
            label_STATUS.Text = "ok";
            SqlLiteConn conn = new SqlLiteConn();

            string sql = "INSERT INTO  qianmo  ( username ,  mail ,  password ,  nickname ,  id ,  userid ,  isactive ,  isnamereg ) VALUES ('" + mail + "', ' ', '153037', '', NULL, NULL, '0.0', '0.0');";
            conn.ExecuteScalar(sql, null);
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //new
            string s = webutil.getNewMail();
            JObject jsonObj = JObject.Parse(s);
            JArray jar = JArray.Parse(jsonObj["data"].ToString());
            string temp = jar[0].ToString().Replace("{", "");
            temp = temp.Replace("}", "");
            mail = temp;
            textBox_mail.Text = temp + "@chacuo.net";
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check
            if (mail.Length > 0)
            {
                string s = webutil.checkMail(mail);
                label_STATUS.Text = s;
                if (s.Contains("qianmo"))
                {
                    label_STATUS.Text = "Mail received";
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    JObject jsonObj = JObject.Parse(s);
                    JArray jar = JArray.Parse(jsonObj["MID"].ToString());
                    string temp = jar[0].ToString().Replace("{", "");
                    mid = temp.Replace("}", "");
                }
            }
        }

        /// <summary>
        /// url 解码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string MyUrlDeCode(string str, Encoding encoding)
        {
            return HttpUtility.UrlDecode(str, encoding);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //read
            string activeurl = "";
            //string mailString = webutil.getMail(mail, mid);
            string mailString = webutil.getMail("wilzrq17583", "80256502");
            JObject jsonObj = JObject.Parse(mailString);
            JArray jar = JArray.Parse(jsonObj["DATA"].ToString());
            string temp = jar[0].ToString().Replace("{", "");
            temp = MyUrlDeCode(temp, Encoding.Unicode);
            webutil.readMail(activeurl);
            button1.Enabled = true;
            button4.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
    }
}