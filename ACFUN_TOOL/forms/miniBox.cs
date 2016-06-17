using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Article.baseUtils;
using Article.forms;
using Article.model;
using Newtonsoft.Json;
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

        private string callUrl = "http://www.acfun.tv/member/#area=mention";

        private string pushUrl = "http://www.acfun.tv/a/";

        private string pushNo = "";

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
            //timer2.Start();
            this.BackgroundImage = Properties.Resources._25;
        }

        #endregion - 构造函数 -

        #region - 事件 -

        private void linkLabel_call_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(callUrl);
        }

        private void linkLabel_push_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(pushUrl + pushNo);
            linkLabel_call.Text = "0";
            this.BackgroundImage = Properties.Resources._37;
        }

        private void miniBox_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th = new Thread(new ThreadStart(openMainForm));
            th.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(getNewApiJsonString));
            th.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // BindControls();
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
                if (con.getIsArticle() == "1")
                {
                    comment comment = new comment();
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

        /// <summary>
        /// 查询是否有新投稿
        /// </summary>
        /// <returns></returns>
        public void getNewApiJsonString()
        {
            List<Article.Model.Article> articleList = getArticleList(1);
            if (articleList.Count > 0)
            {
                if (articleList[0].getComments() == "0" && ("ac" + articleList[0].getContentId() != pushNo))
                {
                    pushNo = "ac" + articleList[0].getContentId();
                    playSound();
                    //linkLabel_call.Text = "1";
                    this.BackgroundImage = Properties.Resources._08;
                }
            }
            return;
        }

        public List<Article.Model.Article> getArticleList(int pageNo)
        {
            List<Article.Model.Article> articleList = new List<Model.Article>();
            WebUtil util = new WebUtil();
            //获取该页中所有的文章编号
            string articleNoList = util.GetArticleList(10, pageNo);
            if (articleNoList.Length > 0)
            {
                JObject jsonObj = JObject.Parse(articleNoList);
                string list = ((JObject)((JObject)jsonObj["data"])["page"])["list"].ToString();
                JArray alist = JArray.Parse(list);
                for (int i = 0; i < alist.Count; ++i)  //遍历JArray
                {
                    Article.Model.Article article = new Article.Model.Article();
                    JObject tempo = JObject.Parse(alist[i].ToString());
                    article.setChannelId(tempo["channelId"].ToString());
                    article.setComments(tempo["comments"].ToString());
                    article.setContentId(tempo["contentId"].ToString());
                    article.setCover(tempo["cover"].ToString());
                    article.setDescription(tempo["description"].ToString());
                    article.setIsArticle(tempo["isArticle"].ToString());
                    article.setIsRecommend(tempo["isRecommend"].ToString());
                    article.setReleaseDate(tempo["releaseDate"].ToString());
                    article.setStows(tempo["stows"].ToString());
                    article.setTitle(tempo["title"].ToString());
                    article.setToplevel(tempo["toplevel"].ToString());
                    article.setTxt(tempo["description"].ToString());
                    article.setUser(tempo["user"].ToString());
                    article.setViewOnly(tempo["viewOnly"].ToString());
                    article.setViews(tempo["views"].ToString());
                    articleList.Add(article);
                }
            }
            return articleList;
        }

        #endregion - 方法 -
    }
}