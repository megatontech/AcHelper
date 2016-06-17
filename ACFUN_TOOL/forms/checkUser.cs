using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Article.baseUtils;
using Article.model;
using Newtonsoft.Json;

namespace Article.forms
{
    public partial class checkUser : Form
    {
        #region - 变量 -

        private WebUtil webutil = new WebUtil();

        private SqlLiteConn conn = new SqlLiteConn();

        #endregion - 变量 -

        #region - Delegate -

        private delegate void SetTextCallBack(string text);

        #endregion - Delegate -

        #region - 构造函数 -

        public checkUser()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        #endregion - 构造函数 -

        #region - 事件 -

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(check));
            th.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(fillUserInfo));
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ThreadPool.SetMinThreads(100,100);
            //ThreadPool.SetMaxThreads(1000,1000);
            //Thread th = new Thread(new ThreadStart(checkOldUser));
            //th.Start();
            Parallel.For(0, 15, (i) => { checkOldUser(); });
        }

        /// <summary>
        /// 修改归属地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Parallel.For(0, 15, (i) => { updateFrom(); });
        }

        #endregion - 事件 -

        #region - 方法 -

        private void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallBack stcb = new SetTextCallBack(SetText);
                this.Invoke(stcb, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }

        private void check()
        {
            string s = "";
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username from regname where isreg = 0;";
            dt = conn.ExecuteDataTable(sql);
            //conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s += dt.Rows[i]["username"].ToString() + "   的状态为：";
                bool isThisUserUnique = webutil.checkUsernameReg(dt.Rows[i]["username"].ToString());
                if (isThisUserUnique)
                {
                    s += "  可以使用   ";
                    sql = "update regname set isused = 0 where username = '" + dt.Rows[i]["username"].ToString() + "';";
                    conn.ExecuteScalar(sql);
                }
                else
                {
                    s += "  已被注册  ";
                    sql = "update regname set isused = 1 where username = '" + dt.Rows[i]["username"].ToString() + "';";
                    conn.ExecuteScalar(sql);
                }
                SetText("\r\n" + s);
            }
        }

        private void fillUserInfo()
        {
            string s = "";
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username from user ";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s = dt.Rows[i]["username"].ToString() + "   的uid为：";
                string usercardString = webutil.getUserInfo(dt.Rows[i]["username"].ToString());
                if (!usercardString.Contains("用户被封禁") && !usercardString.Contains("用户不存在"))
                {
                    string uid = "";
                    Root root = (Root)JsonConvert.DeserializeObject(usercardString, typeof(Root));
                    if (root != null)
                    {
                        uid = root.getuserjson().getUid();
                        if (uid == "" || uid == null)
                        {
                            MessageBox.Show("空");
                            return;
                        }
                        else
                        {
                            //{"userjson":{"currExp":61,"stows":1,"comments":65,"gender":1,"level":22,"sign":"人家真的不搞基的。。","follows":0,"lastLoginDate":"2015-04-26 15:01:46.0","avatar":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/26143138p36q.jpg","posts":1,"followed":0,"lastLoginIp":"113.90.21.*","fans":0,"uid":1292228,"regTime":"2015-04-25 22:10:44.0","nextLevelNeed":100,"comeFrom":"","name":"一个不搞基的男孩子","dTime":"","expPercent":22,"isFriend":0,"views":0},"success":true}
                            //更新基本信息
                            s += root.ToString();
                            sql = "update user set currexp = " + root.getuserjson().getCurrExp() + ", level = " + root.getuserjson().getLevel() + " ,follows=" + root.getuserjson().getFollows() + " ,lastlogindate= '" + root.getuserjson().getLastLoginDate() + "',stows=" + root.getuserjson().getStows() + " ,comments=" + root.getuserjson().getComments() + " ,gender=" + root.getuserjson().getGender() + " ,sign='" + root.getuserjson().getSign() + "' ,avatar='" + root.getuserjson().getAvatar() + "' ,posts=" + root.getuserjson().getPosts() + " ,followed=" + root.getuserjson().getFollowed() + " ,lastloginip='" + root.getuserjson().getLastLoginIp() + "' ,fans=" + root.getuserjson().getFans() + " ,regTime='" + root.getuserjson().getRegTime() + "' ,nextlevelneed=" + root.getuserjson().getNextLevelNeed() + "  ,comefrom= '" + root.getuserjson().getComeFrom() + "',dtime='" + root.getuserjson().getDTime() + "' ,exppercent=" + root.getuserjson().getExpPercent() + " ,isfriend=" + root.getuserjson().getIsFriend() + " ,views=" + root.getuserjson().getViews() + " " +
                                " where username = '" + dt.Rows[i]["username"].ToString() + "';";
                            conn.ExecuteScalar(sql);
                            //更新uid
                            //s += uid;

                            sql = "update user set userid = " + uid + " where username = '" + dt.Rows[i]["username"].ToString() + "';";
                            conn.ExecuteScalar(sql);
                            SetText("\n" + s);
                        }
                    }
                }
            }
        }

        private void fillData(DataTable dt, int i)
        {
            string sql = "";
            string usercardString = webutil.getUserInfo(dt.Rows[i]["account"].ToString());
            if (!usercardString.Contains("用户被封禁") && !usercardString.Contains("用户不存在"))
            {
                string uid = "";
                Root root = (Root)JsonConvert.DeserializeObject(usercardString, typeof(Root));
                if (root != null)
                {
                    uid = root.getuserjson().getUid();
                    if (uid == "" || uid == null)
                    {
                        MessageBox.Show("空");
                        return;
                    }
                    else
                    {
                        sql = "update acfunolduser set userid = " + uid + ",id = " + i + ", currexp = " + root.getuserjson().getCurrExp() + ", level = " + root.getuserjson().getLevel() + " ,follows=" + root.getuserjson().getFollows() + " ,lastlogindate= '" + root.getuserjson().getLastLoginDate() + "',stows=" + root.getuserjson().getStows() + " ,comments=" + root.getuserjson().getComments() + " ,gender=" + root.getuserjson().getGender() + " ,sign='" + root.getuserjson().getSign() + "' ,avatar='" + root.getuserjson().getAvatar() + "' ,posts=" + root.getuserjson().getPosts() + " ,followed=" + root.getuserjson().getFollowed() + " ,lastloginip='" + root.getuserjson().getLastLoginIp() + "' ,fans=" + root.getuserjson().getFans() + " ,regTime='" + root.getuserjson().getRegTime() + "' ,nextlevelneed=" + root.getuserjson().getNextLevelNeed() + "  ,comefrom= '" + root.getuserjson().getComeFrom() + "',dtime='" + root.getuserjson().getDTime() + "' ,exppercent=" + root.getuserjson().getExpPercent() + " ,isfriend=" + root.getuserjson().getIsFriend() + " ,views=" + root.getuserjson().getViews() + " " +
                            " where account = '" + dt.Rows[i]["account"].ToString() + "';";
                        conn.ExecuteScalar(sql);
                    }
                }
            }
        }

        private void checkOldUser()
        {
            string s = "";
            DataTable dt = null;
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select account from acfunolduser ";
            dt = conn.ExecuteDataTable(sql);
            conn.ExecuteDataTable(sql);
            for (int i = 118132; i < dt.Rows.Count; i++)
            {
                // s += dt.Rows[i]["account"].ToString() + "   的uid为：";
                string usercardString = webutil.getUserInfo(dt.Rows[i]["account"].ToString());
                if (!usercardString.Contains("用户被封禁") && !usercardString.Contains("用户不存在"))
                {
                    string uid = "";
                    Root root = (Root)JsonConvert.DeserializeObject(usercardString, typeof(Root));
                    if (root != null)
                    {
                        uid = root.getuserjson().getUid();
                        if (uid == "" || uid == null)
                        {
                            MessageBox.Show("空");
                            return;
                        }
                        else
                        {
                            //{"userjson":{"currExp":61,"stows":1,"comments":65,"gender":1,"level":22,"sign":"人家真的不搞基的。。","follows":0,"lastLoginDate":"2015-04-26 15:01:46.0","avatar":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/26143138p36q.jpg","posts":1,"followed":0,"lastLoginIp":"113.90.21.*","fans":0,"uid":1292228,"regTime":"2015-04-25 22:10:44.0","nextLevelNeed":100,"comeFrom":"","name":"一个不搞基的男孩子","dTime":"","expPercent":22,"isFriend":0,"views":0},"success":true}
                            //更新基本信息

                            string usersign = "";
                            if (root.getuserjson().getSign() != null)
                            {
                                usersign = root.getuserjson().getSign().Replace("\'", "");
                            }
                            string sign = " sign='" + usersign + "',";
                            //sign = sign.Replace("\'", "");
                            sql = "update acfunolduser set userid = " + uid + ",id = " + i + ", currexp = " + root.getuserjson().getCurrExp() + ", level = " + root.getuserjson().getLevel() + " ,follows=" + root.getuserjson().getFollows() + " ,lastlogindate= '" + root.getuserjson().getLastLoginDate() + "',stows=" + root.getuserjson().getStows() + " ,comments=" + root.getuserjson().getComments() + " ,gender=" + root.getuserjson().getGender() + " ," + sign + " avatar='" + root.getuserjson().getAvatar() + "' ,posts=" + root.getuserjson().getPosts() + " ,followed=" + root.getuserjson().getFollowed() + " ,lastloginip='" + root.getuserjson().getLastLoginIp() + "' ,fans=" + root.getuserjson().getFans() + " ,regTime='" + root.getuserjson().getRegTime() + "' ,nextlevelneed=" + root.getuserjson().getNextLevelNeed() + "  ,comefrom= '" + root.getuserjson().getComeFrom() + "',dtime='" + root.getuserjson().getDTime() + "' ,exppercent=" + root.getuserjson().getExpPercent() + " ,isfriend=" + root.getuserjson().getIsFriend() + " ,views=" + root.getuserjson().getViews() + " " +
                                 " where account = '" + dt.Rows[i]["account"].ToString() + "';";
                            conn.ExecuteScalar(sql);
                            //更新uid
                            s = uid;
                            SetText("\n" + s);
                        }
                    }
                }
            }
        }

        private void updateFrom()
        {
            for (int i = 0; i < 10; i++)
            {
                string s = webutil.login("西方媒休", "153037");
                webutil.setFrom(textBox2.Text.Trim(), webutil.cookiec);
            }
        }

        #endregion - 方法 -
    }
}