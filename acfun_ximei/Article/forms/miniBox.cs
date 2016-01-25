using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Article.baseUtils;
using Newtonsoft.Json;
using Article.model;
using System.Collections.Generic;
using Article.forms;
using Newtonsoft.Json.Linq;
namespace Article
{
    public partial class miniBox : Form
    {
        #region - 变量 -

        private WebUtil webutil = new WebUtil();

        private SysConf sys = new SysConf();

        private Notice noti = null;

        private Point currPos, newPos, fromPos, fromNewPos;

        private bool IsMouseDown = false;

        private List<contents> contentList = new List<contents>();

        #endregion - 变量 -

        #region - 构造函数 -

        public miniBox()
        {
            this.Top = Screen.PrimaryScreen.Bounds.Height - 50;
            this.Left = Screen.PrimaryScreen.Bounds.Height - 20;
            this.Width = 110;
            this.Height = 95;
            InitializeComponent();
            Thread th = new Thread(new ThreadStart(BindData));
            th.Start();
            BindControls();
            timer1.Start();
            timer2.Start();
            this.BackgroundImage = Properties.Resources._25;
        }

        #endregion - 构造函数 -

        #region - 事件 -

        private void linkLabel_call_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void linkLabel_push_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void miniBox_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(new ThreadStart(openMainForm));
            th.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(getNewPush));
            th.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            BindControls();
        }

        private void miniBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //确定当前位置
                IsMouseDown = true;
                currPos = Control.MousePosition;
                fromPos = Location;
            }
        }

        private void miniBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                //确定新位置
                newPos = Control.MousePosition;
                //
                fromNewPos.X = newPos.X - currPos.X + fromPos.X;
                fromNewPos.Y = newPos.Y - currPos.Y + fromPos.Y;
                Location = fromNewPos;
                fromPos = fromNewPos;
                currPos = newPos;
            }
        }

        private void miniBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsMouseDown = false;
            }
        }

        #endregion - 事件 -

        #region - 方法 -

        /// <summary>
        /// 初始化绑定数据
        /// </summary>
        private void BindData()
        {
            //%E8%A5%BF%E6%96%B9%E5%AA%92%E4%BD%93
            string s = webutil.login("西方媒体", "153037");
            string s1 = webutil.checkIn(webutil.cookiec);
            this.getNewPush();
            playSound();
        }

        private void BindControls()
        {
            if (noti != null)
            {
                if (linkLabel_call.Text != noti.mention.ToString())
                {
                    linkLabel_call.Text = noti.mention.ToString();
                    this.BackgroundImage = Properties.Resources._37;
                    playSound();
                }
                if (linkLabel_push.Text != noti.newPush.ToString())
                {
                    linkLabel_push.Text = noti.newPush.ToString();
                    this.BackgroundImage = Properties.Resources._08;

                    playSound();
                    //Thread sofath = new Thread(new ThreadStart(getSofa));
                    //sofath.Start();
                }
            }
            else
            {
                this.BackgroundImage = Properties.Resources._03;
            }
        }

        /// <summary>
        /// 抢沙发
        /// </summary>
        public void getSofa()
        {
            //获取投稿列表并选出文章投稿
            string s1 = webutil.getPublish(webutil.cookiec);
            JObject jsonObj = JObject.Parse(s1);
            JArray jar = JArray.Parse(jsonObj["contents"].ToString());
            JObject j = JObject.Parse(jar[0].ToString());
            contentList = JsonConvert.DeserializeObject(s1, typeof(List<contents>)) as List<contents>;
            if (contentList.Count > 0)
            {
                contents con = contentList[0];
                if(con.getIsArticle()=="1")
                {
                    CommentBox comment = new CommentBox();
                    comment.Show();
                }
            }
        }

        private void playSound()
        {
            if (sys.IsSoundEnable)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.bilibili);
                player.Load();
                player.Play();
            }
        }

        public void openMainForm()
        {
            sys.IsFirstRun = false;
            Acfun form = new Acfun();
            form.Show();
        }

        /// <summary>
        /// 刷新是否有新推送和沙发
        /// </summary>
        public void getNewPush()
        {
            string s1 = webutil.getPush(webutil.cookiec);
            noti = JsonConvert.DeserializeObject<Notice>(s1);
        }

        #endregion - 方法 -
    }
}