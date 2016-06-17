using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Article.baseUtils;

namespace Article.forms
{
    public partial class banana : Form
    {
        private SysConf sys = new SysConf();
        private WebUtil webutil = new WebUtil();
        private SqlLiteConn conn = new SqlLiteConn();
        private string acNo = "";
        private int banCount = 5;

        public banana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acNo = this.textBox1.Text;
            banCount = (Int32)this.numericUpDown1.Value;
            if (acNo == "")
            {
                MessageBox.Show("acNo!!!!");
                return;
            }
            Thread th = new Thread(new ThreadStart(throwBananaStart));
            th.Start();
        }

        private void throwBananaStart()
        {
            MessageBox.Show("banana throw start");

            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username,userpassword,userid from user ;";
            dt = conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //string s = webutil.login(dt.Rows[i]["username"].ToString(), dt.Rows[i]["userpassword"].ToString());
                string userid = dt.Rows[i]["userid"].ToString();
                string s1 = webutil.throwBanana(acNo, banCount, userid, webutil.RestoreCookie(dt.Rows[i]["username"].ToString()));
                Thread.Sleep(1000);
            }
            MessageBox.Show("banana OK");
        }
    }
}