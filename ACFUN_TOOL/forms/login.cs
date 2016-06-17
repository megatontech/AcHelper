using System;
using System.Data;
using System.Data.SQLite;
using Article.baseUtils;

namespace Article
{
    public partial class login : DevExpress.XtraEditors.XtraForm
    {
        private SqlLiteConn conn = new SqlLiteConn();
        private DataTable dt = null;

        #region - 构造函数 -

        public login()
        {
            InitializeComponent();
            string sql = "select username,userpassword from user ;";
            dt = conn.ExecuteDataTable(sql);
            BindData();
        }

        #endregion - 构造函数 -

        #region - 事件 -

        /// <summary>
        /// 记录id和对应的密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_add_Click(object sender, EventArgs e)
        {
            string sqlInsert = "insert into user (username,userpassword) values('" + comboBox1.Text + "','" + this.textBox1.Text.Trim() + "');";
            conn.ExecuteScalar(sqlInsert, null);
            string sql = "select username,userpassword from user ;";
            dt = conn.ExecuteDataTable(sql);
            BindData();
            return;
        }

        /// <summary>
        /// 删除id和密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_remove_Click(object sender, EventArgs e)
        {
            string sqlDel = "delete from user where username = '" + comboBox1.SelectedItem.ToString() + "'";
            conn.ExecuteScalar(sqlDel);
            string sql = "select username,userpassword from user ;";
            dt = conn.ExecuteDataTable(sql);
            BindData();

            return;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                string sql = "select userpassword from user where [username] = @username";
                SQLiteParameter[] pars = new SQLiteParameter[] { new SQLiteParameter("@username", comboBox1.SelectedItem.ToString()) };
                DataTable dtpwd = conn.ExecuteDataTable(sql, pars);
                if (dtpwd.Rows.Count > 0)
                {
                    this.textBox1.Text = dtpwd.Rows[0]["userpassword"].ToString();
                }
            }

            return;
        }

        #endregion - 事件 -

        #region - 方法 -

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            this.comboBox1.Items.Clear();
            this.textBox1.Text = "请填入密码...";
            this.comboBox1.Text = "请填入账号...";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.comboBox1.Items.Add(dt.Rows[i]["username"].ToString());
            }
            return;
        }

        #endregion - 方法 -
    }
}