using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Windows.Forms;
using Article.baseUtils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraSplashScreen;
using Article.forms;

namespace Article
{
    public partial class Acfun : RibbonForm
    {
        private SysConf sys = new SysConf();
        private WebUtil webutil = new WebUtil();

        public Acfun()
        {
            if (sys.IsFirstRun)
            {
                SplashScreenManager.ShowForm(typeof(Splash));
                System.Threading.Thread.Sleep(10000);
                InitializeComponent();
                new Thread(new ThreadStart(checkUserId)).Start();
                SplashScreenManager.CloseForm();
            }
            else
            {
                InitializeComponent();
            }
        }

        /// <summary>
        /// 检查是否为第一次使用和是否有id记录
        /// </summary>
        /// <returns></returns>
        public void checkUserId()
        {
            bool isUserIdRec = false;
            SqlLiteConn conn = new SqlLiteConn();
            DataTable dt = conn.GetSchema();
            if (dt.Rows.Count > 0)
            {
                //是否有记录
                SQLiteParameter[] pars = new SQLiteParameter[] { new SQLiteParameter("", "") };
                string sql = "select count() from user where id >0";
                SQLiteDataReader r = conn.ExecuteReader(sql, pars);
                if (r.Read() && (r.GetInt32(0) > 0))
                {
                    r.Close();
                    isUserIdRec = true;
                }
                else
                {
                    isUserIdRec = false;
                }
            }
            else
            {
                //空数据库初始化
                string sql = @"
                    DROP TABLE IF EXISTS 'main'.'user';
                    CREATE TABLE 'user' (
                    'id'  INTEGER NOT NULL,
                    'userid'  INTEGER,
                    'username'  TEXT NOT NULL,
                    'userpassword'  TEXT NOT NULL,
                    'moni'  REAL,
                    PRIMARY KEY ('id')
                    );";
                conn.ExecuteNonQuery(sql);
            }
            if (!isUserIdRec)
            {
                login loginform = new login();
                loginform.Show();
            }
        }

    

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_checkin_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(checkIn));
            th.Start();
        }
        private void checkIn() 
        {
            MessageBox.Show("check in start");

            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username,userpassword from user ;";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = webutil.login(dt.Rows[i]["username"].ToString(), dt.Rows[i]["userpassword"].ToString());
                string s1 = webutil.checkIn(webutil.cookiec);
                Thread.Sleep(20000);
            }
                MessageBox.Show("check in success!");
            

        }

        private void button_notice_Click(object sender, EventArgs e)
        {
            miniBox box = new miniBox();
            box.Show();
        }

        private void button_userManage_Click(object sender, EventArgs e)
        {
            login loginform = new login();
            loginform.Show();
        }

        private void Acfun_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)  //判断是否最小化
            {
                this.ShowInTaskbar = false;  //不显示在系统任务栏
                notifyIcon.Visible = true;  //托盘图标可见
            }
        }

        

        #region 最小化到任务栏
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;  //显示在系统任务栏
                this.WindowState = FormWindowState.Normal;  //还原窗体
                notifyIcon.Visible = false;  //托盘图标隐藏
            }
        }
        private ContextMenu notifyiconMnu;
        /// <summary>
        /// 最小化到任务栏
        /// </summary>
        private void Initializenotifyicon()
        {
            //定义一个MenuItem数组，并把此数组同时赋值给ContextMenu对象 
            MenuItem[] mnuItms = new MenuItem[3];
            mnuItms[0] = new MenuItem();
            mnuItms[0].Text = "显示窗口";
            mnuItms[0].Click += new System.EventHandler(this.notifyIcon1_showfrom);

            mnuItms[1] = new MenuItem("-");

            mnuItms[2] = new MenuItem();
            mnuItms[2].Text = "退出系统";
            mnuItms[2].Click += new System.EventHandler(this.ExitSelect);
            mnuItms[2].DefaultItem = true;

            notifyiconMnu = new ContextMenu(mnuItms);
            notifyIcon.ContextMenu = notifyiconMnu;
            //为托盘程序加入设定好的ContextMenu对象 
        }


        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        public void notifyIcon1_showfrom(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        public void ExitSelect(object sender, System.EventArgs e)
        {
            //隐藏托盘程序中的图标 
            notifyIcon.Visible = false;
            //关闭系统 s
            Application.Exit();
        }
        private void Form_main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) //判断是否最小化
            {
                notifyIcon.Visible = true;
                this.Hide();
                this.ShowInTaskbar = false;
                Initializenotifyicon();
            }
        }
        /// <summary>
        /// pinglun
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComment_Click(object sender, EventArgs e)
        {
            CommentBox box = new CommentBox();
            box.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bananaThrow banana = new bananaThrow();
            banana.Show();
        }
        #endregion

        

        
    }
}