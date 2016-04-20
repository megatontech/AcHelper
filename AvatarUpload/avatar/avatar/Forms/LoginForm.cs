using System;
using System.Windows.Forms;

namespace avatar
{
    public partial class LoginForm : Form
    {
        public bool isLogin = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //登陆
            string loginResult = WebUtil.login(txtID.Text.Trim(), txtPwd.Text.Trim());
            if ((!loginResult.Contains("您输入的帐号或密码错误")) || (!loginResult.Contains("用户名不存在")))
            {
                isLogin = true;
            }
            if (isLogin)
            {
                Avatar.isLogin = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("error:" + loginResult);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}