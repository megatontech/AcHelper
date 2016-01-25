using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Article.baseUtils;

namespace Article.forms
{
    public partial class bananaThrow : Form
    {
        private SysConf sys = new SysConf();
        private WebUtil webutil = new WebUtil();
        SqlLiteConn conn = new SqlLiteConn();
        string acNo = "";
        public bananaThrow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acNo = this.textBox1.Text;
            if(acNo=="")
            {
                MessageBox.Show("acNo!!!!");

                return;
            }
            Thread th = new Thread(new ThreadStart(checkIn));
            th.Start();
        }

        
        private void checkIn() 
        {
            MessageBox.Show("banana throw start");

            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username,userpassword,userid from user ;";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = webutil.login(dt.Rows[i]["username"].ToString(), dt.Rows[i]["userpassword"].ToString());
                string userid = dt.Rows[i]["userid"].ToString();
                string s1 = webutil.throwBanana(acNo,userid,webutil.cookiec);
                Thread.Sleep(20000);
            }
            MessageBox.Show("banana OK");
        }

    }
}
