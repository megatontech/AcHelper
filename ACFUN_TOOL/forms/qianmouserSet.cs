using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using Article.baseUtils;

namespace Article.forms
{
    public partial class qianmouserSet : Form
    {
        private WebUtil webutil = new WebUtil();

        public qianmouserSet()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            BindControl();
        }

        public qianmouserSet(string username, string mailbox)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            this.textBox_mail.Text = mailbox;
            this.textBox_name.Text = username;
            BindControl();
        }

        public void BindData()
        {
            DataTable dtname = null;
            DataTable dtmail = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sqlname = "select username from regname where isreg = 0 and isused = 0 limit 1;";
            string sqlmail = "select username from qianmo where isnamereg = 0  limit 1;";
            dtname = conn.ExecuteDataTable(sqlname);
            dtmail = conn.ExecuteDataTable(sqlmail);
            if (dtname.Rows.Count == 0)
            {
                MessageBox.Show("error! username count is 0");
                return;
            }
            else if (dtmail.Rows.Count == 0)
            {
                MessageBox.Show("error! mail count is 0");
                return;
            }
            this.textBox_name.Text = dtname.Rows[0]["username"].ToString();
            this.textBox_mail.Text = dtmail.Rows[0]["username"].ToString();
            string id = Guid.NewGuid().ToString();
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
            label_STATUS.Text = "Name set start";
            string s = webutil.loginQianmo(textBox_mail.Text.Trim(), textBox_pwd.Text.Trim());
            if (webutil.setQianmoName(textBox_name.Text.Trim(), webutil.cookiec))
            {
                SqlLiteConn conn = new SqlLiteConn();
                string sql = "update qianmo set nickname='" + textBox_name.Text + "',isnamereg =1.0 where username = '" + textBox_mail.Text + "';";
                conn.ExecuteScalar(sql, null);
                string sqlUpdate = " update regname set  isused = 1 where username = '" + textBox_name.Text + "'";
                conn.ExecuteScalar(sqlUpdate, null);
                label_STATUS.Text = "Name set ok";
                BindData();
            }
            else { MessageBox.Show("error!"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label_STATUS.Text = "用户名已舍弃";
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sqlUpdate = " update regname set isreg = 1 , isused = 1 where username = '" + textBox_name.Text + "'";
            conn.ExecuteScalar(sqlUpdate, null);
            string sql = "select username from regname where isreg = 0 and isused = 0 limit 1;";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            this.textBox_name.Text = dt.Rows[0]["username"].ToString();
        }

        //检查是否被占用
        private void button2_Click(object sender, EventArgs e)
        {
            label_STATUS.Text = "用户名可用性检测中";
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username from regname ;";
            dt = conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (webutil.checkQianmoName(dt.Rows[i]["username"].ToString()))
                {
                    string sqlUpdate = " update regname set  isused = 1 where username = '" + dt.Rows[i]["username"].ToString() + "'";
                    conn.ExecuteScalar(sqlUpdate, null);
                }
            }
            label_STATUS.Text = "用户名可用性检测完成";
        }
    }
}