using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace Article.baseUtils
{
    /// <summary>
    /// 实现网站登录类
    /// </summary>
    public class WebUtil
    {
        #region - 变量 -

        /// <summary>
        /// 网站Cookies
        /// </summary>
        private string _cookieHeader = string.Empty;

        /// <summary>
        /// cookie管理
        /// </summary>
        private CookieContainer cookiecontainer;

        /// <summary>
        /// 网站编码
        /// </summary>
        private string _code = string.Empty;

        private string _pageContent = string.Empty;

        private Dictionary<string, string> _para = new Dictionary<string, string>();

        private CookieCollection cookies;

        /// <summary>
        /// 登录
        /// </summary>
        private string loginUrl = "http://www.acfun.tv/login.aspx";

        /// <summary>
        /// 签到
        /// </summary>
        private string checkinUrl = "http://www.acfun.tv/member/checkin.aspx";

        /// <summary>
        /// 获取消息数
        /// </summary>
        private string getpushUrl = "http://www.acfun.tv/member/unRead.aspx";

        /// <summary>
        /// 个人推送
        /// </summary>
        private string getPublishUrl = "http://www.acfun.tv/member/publishContent.aspx?isGroup=0&groupId=-1&pageSize=10&pageNo=1";

        /// <summary>
        /// 获取评论json
        /// </summary>
        private string commentUrl = "http://www.acfun.tv/comment_list_json.aspx?contentId=&currentPage=1";

        /// <summary>
        /// 验证码
        /// </summary>
        private string captchaUrl = "http://www.acfun.tv/captcha.svl";

        /// <summary>
        /// 检测用户注册
        /// </summary>
        private string checkUserNameUrl = "http://www.acfun.tv/username_unique.aspx?username=";

        /// <summary>
        /// 注册
        /// </summary>
        private string regUserUrl = "http://www.acfun.tv/rega.aspx";

        /// <summary>
        /// 用户信息
        /// </summary>
        private string userCardUrl = "http://www.acfun.tv/usercard.aspx?username=";

        /// <summary>
        /// 更新用户信息
        /// </summary>
        private string updateUserInfoUrl = "http://www.acfun.tv/member/profileSubmit.aspx";

        public CookieContainer cookiec = new CookieContainer();

        #endregion - 变量 -

        #region - qianmo -

        public string qianmoregUrl = "http://qianmo.com/accounts/register";

        public string qianmoUrl = "http://qianmo.com/";

        public string qianmologinUrl = "http://qianmo.com/accounts/login";

        public string qianmocheckUrl = "http://qianmo.com/accounts/check_display_name";

        public string qianmosetnameUrl = "http://qianmo.com/settings/profile";

        public string qianmoinfoUrl = "http://qianmo.com/api/v1/user";

        public string randomMailUrl = "http://24mail.chacuo.net/enus";

        #endregion - qianmo -

        #region - 属性 -

        public string CookieHeader
        {
            get
            {
                return _cookieHeader;
            }
            set
            {
                _cookieHeader = value;
            }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string PageContent
        {
            get { return _pageContent; }
            set { _pageContent = value; }
        }

        public Dictionary<string, string> Para
        {
            get { return _para; }
            set { _para = value; }
        }

        public CookieCollection Cookies
        {
            get { return cookies; }
            set { cookies = value; }
        }

        #endregion - 属性 -

        #region - 基础方法 -

        /// <summary>
        /// 功能描述：获取推送
        /// </summary>
        /// <param name="strURL">获取网站的某页面的地址</param>
        /// <param name="strReferer">引用的地址</param>
        /// <returns>返回页面内容</returns>
        public string GetPuchPage(string strURL, string strReferer, CookieContainer cookiec)
        {
            string strResult = "";
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.KeepAlive = true;
                myHttpWebRequest.Accept = "*/*";
                myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate ");
                myHttpWebRequest.CookieContainer = cookiec;
                myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
                myHttpWebRequest.ContentType = "application/json;charset=UTF-8";
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.Timeout = 300000;
                HttpWebResponse response = null;
                System.IO.StreamReader sr = null;
                BinaryReader br = null;
                response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                if (cookiec != null)
                {
                    response.Cookies = cookiec.GetCookies(myHttpWebRequest.RequestUri);
                }
                Stream streamReceive;
                string gzip = response.ContentEncoding;
                if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
                {
                    streamReceive = response.GetResponseStream();
                }
                else
                {
                    streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                }
                sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);
                br = new System.IO.BinaryReader(streamReceive, Encoding.UTF8);
                //if (response.ContentLength > 1)
                //{
                strResult = sr.ReadToEnd();
                //}
                //else
                //{
                //    char[] buffer = new char[64];
                //    int count = 0;
                //    StringBuilder sb = new StringBuilder();
                //    while ((count = br.Read(buffer, 0, buffer.Length)) > 0)
                //    {
                //        sb.Append(new string(buffer));
                //    }
                //    strResult = sb.ToString();
                //}
                sr.Close();
                response.Close();
            }
            catch (Exception e)
            {
                //throw;
            }
            finally
            {
                Console.WriteLine("!!!!!!!!!");
            }
            return strResult;
        }

        /// <summary>
        /// 登录获得post请求后响应的数据
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="referUrl">请求引用地址</param>
        /// <param name="data">请求带的数据</param>
        /// <returns>响应内容</returns>
        public string PostData(string postUrl, string referUrl, string data)
        {
            string result = "";
            try
            {
                //命名空间System.Net下的HttpWebRequest类
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
                //参照浏览器的请求报文 封装需要的参数 这里参照ie9
                //浏览器可接受的MIME类型
                request.Accept = "text/plain, */*; q=0.01";
                //包含一个URL，用户从该URL代表的页面出发访问当前请求的页面
                request.Referer = referUrl;
                //浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.UserAgent = "ShengDiYaGe/1.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                //请求方式
                request.Method = "POST";
                request.Timeout = 20000;
                //是否保持常连接
                request.KeepAlive = true;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                //表示请求消息正文的长度
                request.ContentLength = data.Length;
                Stream postStream = request.GetRequestStream();
                byte[] postData = Encoding.UTF8.GetBytes(data);
                //将传输的数据，请求正文写入请求流
                postStream.Write(postData, 0, postData.Length);
                postStream.Dispose();
                //写入cookie
                request.CookieContainer = cookiec;
                request.Headers.Add("cookie:" + this.CookieHeader);
                request.CookieContainer.SetCookies(new Uri(postUrl), this.CookieHeader);
                //响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookiec.GetCookies(request.RequestUri);
                Stream streamReceive;
                string gzip = response.ContentEncoding;
                if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
                {
                    streamReceive = response.GetResponseStream();
                }
                else
                {
                    streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                }
                StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);

                if (response.ContentLength > 1)
                {
                    result = sr.ReadToEnd();
                }
                else
                {
                    char[] buffer = new char[256];
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    while ((count = sr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        sb.Append(new string(buffer));
                    }
                    result = sb.ToString();
                }
                sr.Close();
                response.Close();
                return result;
            }
            catch (Exception)
            {
            }
            finally
            {
                Console.WriteLine("!!!!!!!!!");
            }
            return result;
        }

        /// <summary>
        /// 已登录持有cookie进行post
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="referUrl"></param>
        /// <param name="data"></param>
        /// <param name="cookiec"></param>
        /// <returns></returns>
        public string PostData(string postUrl, string referUrl, string data, CookieContainer cookiec)
        {
            //data = System.Web.HttpUtility.UrlEncode(data);
            string result = "";
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(postUrl);
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.KeepAlive = true;
                myHttpWebRequest.Accept = "*/*";
                myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                myHttpWebRequest.CookieContainer = cookiec;
                myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                myHttpWebRequest.Referer = referUrl;
                myHttpWebRequest.Method = "POST";
                myHttpWebRequest.Timeout = 80000;
                myHttpWebRequest.ContentLength = data.Length;
                Stream postStream = myHttpWebRequest.GetRequestStream();
                byte[] postData = Encoding.UTF8.GetBytes(data);
                postStream.Write(postData, 0, postData.Length);
                postStream.Dispose();
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                response.Cookies = cookiec.GetCookies(myHttpWebRequest.RequestUri);
                Stream streamReceive;
                string gzip = response.ContentEncoding;
                if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
                {
                    streamReceive = response.GetResponseStream();
                }
                else
                {
                    streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                }
                StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);
                if (response.ContentLength > 1)
                {
                    result = sr.ReadToEnd();
                }
                else
                {
                    char[] buffer = new char[256];
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    while ((count = sr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        sb.Append(new string(buffer));
                    }
                    result = sb.ToString();
                }
                sr.Close();
                response.Close();
                string s = result;
                return s;
            }
            catch { }
            finally
            {
                Console.WriteLine("!!!!!!!!!");
            }
            return "";
        }

        /// <summary>
        /// url 解码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public string MyUrlDeCode(string str, Encoding encoding)
        {
            if (encoding != null)
            {
                Encoding utf8 = Encoding.UTF8;
                //首先用utf-8进行解码                   
                string code = HttpUtility.UrlDecode(str.ToUpper(), utf8);

                //将已经解码的字符再次进行编码.
                string encode = HttpUtility.UrlEncode(code, utf8).ToUpper();
                if (str == encode)
                    encoding = Encoding.UTF8;
                else
                    encoding = Encoding.GetEncoding("gb2312");
            }
            return HttpUtility.UrlDecode(str, encoding);
        }

        /// <summary>
        /// get all cookie
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();
            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });
            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }

        public void SaveCookie(string username)
        {
            List<Cookie> cooklist = GetAllCookies(cookiec);
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "";
            sql = "delete from cookie  where username = '" + username + "';";
            conn.ExecuteScalar(sql);
            foreach (Cookie cookie in cooklist)
            {
                string cookieString = JsonConvert.SerializeObject(cookie);
                sql = "insert into cookie (username,cookie) values ('" + username + "','" + cookieString + "');";
                conn.ExecuteScalar(sql);
            }
        }

        public CookieContainer RestoreCookie(string username)
        {
            DataTable dt = null;
            cookiec = new CookieContainer();
            SqlLiteConn conn = new SqlLiteConn();
            string sql = "select username,cookie from cookie where username = '" + username + "' ;";
            dt = conn.ExecuteDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Cookie ck = JsonConvert.DeserializeObject<Cookie>(dt.Rows[i]["cookie"].ToString());
                cookiec.Add(ck);
            }
            return cookiec;
        }

        /// <summary>
        /// 获取服务器图片
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        public Bitmap getImage(string imageUrl)
        {
            string errorString = "";
            Bitmap b = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imageUrl);
                request.Timeout = 88000;
                request.CookieContainer = cookiec;
                request.ServicePoint.ConnectionLimit = 1000;
                request.ReadWriteTimeout = 13000;
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookiec.GetCookies(request.RequestUri);
                Stream resStream = response.GetResponseStream();
                b = new Bitmap(resStream);
                response.Close();
                return b;
            }
            catch (Exception e)
            {
                errorString = e.Message;
            }
            finally
            {
                Console.WriteLine("!!!!!!!!!" + errorString);
            } return b;
        }

        /// <summary>
        /// get获取json信息
        /// </summary>
        /// <param name="getStringUrl"></param>
        /// <returns></returns>
        public string getString(string getStringUrl)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(getStringUrl);
                request.Timeout = 200000;
                request.ServicePoint.ConnectionLimit = 100;
                request.ReadWriteTimeout = 300000;
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                Stream streamReceive;
                string gzip = response.ContentEncoding;
                if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
                {
                    streamReceive = response.GetResponseStream();
                }
                else
                {
                    streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                }
                StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);
                if (response.ContentLength > 1)
                {
                    strResult = sr.ReadToEnd();
                }
                else
                {
                    char[] buffer = new char[256];
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    while ((count = sr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        sb.Append(new string(buffer));
                    }
                    strResult = sb.ToString();
                }
                sr.Close();
                response.Close();
                return strResult;
            }
            catch (Exception e)
            {
            }
            finally
            {
                Console.WriteLine("!!!!!!!!!");
            } return strResult;
        }

        /// <summary>
        /// 功能描述：在PostLogin成功登录后记录下Headers中的cookie，然后获取此网站上其他页面的内容
        /// </summary>
        /// <param name="strURL">获取网站的某页面的地址</param>
        /// <param name="strReferer">引用的地址</param>
        /// <returns>返回页面内容</returns>
        public string GetPage(string strURL, string strReferer, CookieContainer cookiec)
        {
            string strResult = "";
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.KeepAlive = false;
                myHttpWebRequest.Accept = "*/*";
                myHttpWebRequest.Referer = strReferer;
                myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                myHttpWebRequest.CookieContainer = cookiec;
                myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
                myHttpWebRequest.ContentType = "application/json;charset=UTF-8";
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.Timeout = 300000;
                HttpWebResponse response = null;
                System.IO.StreamReader sr = null;
                response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                response.Cookies = cookiec.GetCookies(myHttpWebRequest.RequestUri);
                Stream streamReceive;
                string gzip = response.ContentEncoding;
                if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
                {
                    streamReceive = response.GetResponseStream();
                }
                else
                {
                    streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                }
                sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);
                if (response.ContentLength > 1)
                {
                    strResult = sr.ReadToEnd();
                }
                else
                {
                    char[] buffer = new char[256];
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    while ((count = sr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        sb.Append(new string(buffer));
                    }
                    strResult = sb.ToString();
                }
                sr.Close();
                response.Close();
            }
            catch (Exception e)
            {
                //throw;
            }
            finally
            {
                Console.WriteLine("!!!!!!!!!");
            }
            return strResult;
        }

        #endregion - 基础方法 -

        #region - 方法 -

        /// <summary>
        /// 获取文章区更新
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        public string GetArticleList(int pageSize, int pageNo)
        {
            string url = "http://api.acfun.tv/apiserver/content/channel?channelId=110&pageNo=" + pageNo + "&pageSize=" + pageSize;
            string s = GetPuchPage(url, url, null);
            return s;
        }

        /// <summary>
        /// 尝试签到
        /// </summary>
        /// <returns></returns>
        public string checkIn(CookieContainer cookiec)
        {
            string s = string.Empty;
            s = GetPage(checkinUrl, checkinUrl, cookiec);
            return s;
        }

        /// <summary>
        /// 尝试登录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string login(string username, string password)
        {   //username=%E8%A5%BF%E6%96%B9%E5%AA%92%E4%BD%93&password=123456
            username = System.Web.HttpUtility.UrlEncode(username);
            string s = string.Empty;
            string data = "username=" + username + "&password=" + password;
            s = PostData(loginUrl, loginUrl, data);
            return s;
        }

        /// <summary>
        /// 播放声音
        /// </summary>
        private void playSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.bilibili);
            player.Load();
            player.Play();
        }

        /// <summary>
        /// 获取推送内容
        /// </summary>
        /// <param name="cookiec"></param>
        /// <returns></returns>
        public string getPublish(CookieContainer cookiec)
        {
            string s = "";
            s = GetPage(getPublishUrl, getPublishUrl, cookiec);
            return s;
        }

        /// <summary>
        /// 投食香蕉
        /// </summary>
        /// <param name="acNo"></param>
        /// <param name="banCount"></param>
        /// <param name="userId"></param>
        /// <param name="cookiec"></param>
        /// <returns></returns>
        public string throwBanana(string acNo, int banCount, string userId, CookieContainer cookiec)
        {
            string s = "";
            string data = "contentId=" + acNo + "&count=" + banCount + "&userId=" + userId;
            s = PostData("http://www.acfun.tv/banana/throwBanana.aspx", "http://www.acfun.tv/v/ac" + acNo, data, cookiec);
            return s;
        }

        /// <summary>
        /// 发布评论
        /// </summary>
        /// <param name="PostNo">纯数字ac号</param>
        /// <param name="data"></param>
        public string comment(string PostNo, string data, CookieContainer cookiec)
        {
            //posturl
            //http://www.acfun.tv/comment.aspx
            //data:
            //name:sendComm()
            //token:mimiko
            //quoteId:0
            //text:%E8%A6%81%E9%82%A3%E4%B9%88%E5%A4%9A%E7%9F%B3%E6%B2%B9%E5%B9%B2%E5%98%9B%EF%BC%8C%E5%8D%96%E4%BA%86%E5%8D%96%E4%BA%86
            //cooldown:5000
            //contentId:1832378
            //name=sendComm()&token=mimiko&quoteId=0&text=%E8%A6%81%E9%82%A3%E4%B9%88%E5%A4%9A%E7%9F%B3%E6%B2%B9%E5%B9%B2%E5%98%9B%EF%BC%8C%E5%8D%96%E4%BA%86%E5%8D%96%E4%BA%86&cooldown=5000&contentId=1832378
            //refer
            //http://www.acfun.tv/a/ac1832378
            data = System.Web.HttpUtility.UrlEncode(data);
            data = "name=sendComm()&token=mimiko&quoteId=0&text=" + data + "&cooldown=5000&contentId=" + PostNo + "&quoteName=";
            string result = "";
            try
            {
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.acfun.tv/comment.aspx");
                myHttpWebRequest.AllowAutoRedirect = true;
                myHttpWebRequest.KeepAlive = true;
                myHttpWebRequest.Accept = "*/*";
                myHttpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
                myHttpWebRequest.CookieContainer = cookiec;
                myHttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 2.0.50727)";
                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                myHttpWebRequest.Referer = "http://www.acfun.tv/a/ac" + PostNo;
                myHttpWebRequest.Method = "POST";
                myHttpWebRequest.Timeout = 100000;
                myHttpWebRequest.ContentLength = data.Length;
                Stream postStream = myHttpWebRequest.GetRequestStream();
                byte[] postData = Encoding.UTF8.GetBytes(data);
                postStream.Write(postData, 0, postData.Length);
                postStream.Dispose();
                HttpWebResponse response = (HttpWebResponse)myHttpWebRequest.GetResponse();
                response.Cookies = cookiec.GetCookies(myHttpWebRequest.RequestUri);
                Stream streamReceive;
                string gzip = response.ContentEncoding;
                if (string.IsNullOrEmpty(gzip) || gzip.ToLower() != "gzip")
                {
                    streamReceive = response.GetResponseStream();
                }
                else
                {
                    streamReceive = new System.IO.Compression.GZipStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress);
                }
                StreamReader sr = new System.IO.StreamReader(streamReceive, Encoding.UTF8);
                if (response.ContentLength > 1)
                {
                    result = sr.ReadToEnd();
                }
                else
                {
                    char[] buffer = new char[256];
                    int count = 0;
                    StringBuilder sb = new StringBuilder();
                    while ((count = sr.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        sb.Append(new string(buffer));
                    }
                    result = sb.ToString();
                }
                sr.Close();
                response.Close();
                string s = result;
                return s;
            }
            catch (Exception)
            {
                //throw;
            }
            finally
            {
                Console.WriteLine("!!!!!!!!!");
            }
            return "";
        }

        /// <summary>
        /// 尝试获取推送
        /// </summary>
        /// <returns></returns>
        public string getPush(CookieContainer cookiec)
        {
            string s = string.Empty;
            s = GetPage(getpushUrl, getpushUrl, cookiec);
            return s;
        }

        /// <summary>
        /// 检测用户名是否被占用
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool checkUsernameReg(string userName)
        {
            userName = System.Web.HttpUtility.UrlEncode(userName);
            if (getString(checkUserNameUrl + userName) == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="mailBox"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="invateCode"></param>
        /// <param name="captcha"></param>
        /// <param name="cookiec"></param>
        /// <returns></returns>
        public string regNewUser(string mailBox, string userName, string password, string invateCode, string captcha, CookieContainer cookiec)
        {
            //email=temp3%40megaton.com&name=%E5%BC%82%E4%B9%A1%E5%BC%82%E5%AE%A2&password=153037&password2=153037&captcha=hcgc
            //email=12%40412.com&name=214%E7%AA%81%E5%8F%9123%E5%A5%B9&password=111111&password2=111111&invitationCode=12341234123412341234123412341234&captcha=vvht
            //{"success":true,"result":"注册成功","info":"注册成功","status":200}
            //            键	值
            //请求	POST /rega.aspx HTTP/1.1
            //Accept	*/*
            //Content-Type	application/x-www-form-urlencoded; charset=UTF-8
            //X-Requested-With	XMLHttpRequest
            //Referer	http://www.acfun.tv/reg/
            //Accept-Language	zh-CN
            //Accept-Encoding	gzip, deflate
            //User-Agent	Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko
            //Host	www.acfun.tv
            //Content-Length	113
            //DNT	1
            //Connection	Keep-Alive
            //Cache-Control	no-cache
            mailBox = System.Web.HttpUtility.UrlEncode(mailBox);
            userName = System.Web.HttpUtility.UrlEncode(userName);
            string s = string.Empty;
            string data = string.Empty;
            if (string.IsNullOrEmpty(invateCode))
            {
                data = "email=" + mailBox + "&name=" + userName + "&password=" + password + "&password2=" + password + "&captcha=" + captcha + "";
            }
            else
            {
                data = "email=" + mailBox + "&name=" + userName + "&password=" + password + "&password2=" + password + "&invitationCode=" + invateCode + "&captcha=" + captcha + "";
            }
            s = PostData(regUserUrl, "http://www.acfun.tv/reg/", data, cookiec);
            return s;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        public Bitmap getCaptcha()
        {
            return getImage(captchaUrl);
        }

        /// <summary>
        /// 通过用户名获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public string getUserInfo(string username)
        {
            //{"userjson":{"currExp":61,"stows":1,"comments":65,"gender":1,"level":22,"sign":"人家真的不搞基的。。","follows":0,"lastLoginDate":"2015-04-26 15:01:46.0","avatar":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/26143138p36q.jpg","posts":1,"followed":0,"lastLoginIp":"113.90.21.*","fans":0,"uid":1292228,"regTime":"2015-04-25 22:10:44.0","nextLevelNeed":100,"comeFrom":"","name":"一个不搞基的男孩子","dTime":"","expPercent":22,"isFriend":0,"views":0},"success":true}
            username = System.Web.HttpUtility.UrlEncode(username);
            return getString(userCardUrl + username);
        }

        /// <summary>
        /// 设置归属地
        /// </summary>
        /// <param name="p"></param>
        /// <param name="cookiec"></param>
        public void setFrom(string p, CookieContainer cookiec)
        {
            p = System.Web.HttpUtility.UrlEncode(p);
            //comefrom=%E5%AE%89%E5%BE%BD%2C%E5%90%88%E8%82%A5&qq=337845818&blog=&realname=&gender=-1&sextrend=-1
            string data = "comefrom=" + p + "&qq=337845818&blog=&realname=&gender=-1&sextrend=-1";
            string s = PostData(updateUserInfoUrl, "http://www.acfun.tv/member/", data, cookiec);
            return;
        }

        /// <summary>
        /// 注册阡陌站
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="p"></param>
        public void regQianmo(string mail, string p)
        {
            mail = System.Web.HttpUtility.UrlEncode(mail);
            string data = "email=" + mail + "&password=" + p + "&repeated=" + p + "&agree=on&prehash=false";
            string s = PostData(qianmoregUrl, qianmoUrl, data);
            return;
        }

        /// <summary>
        /// 登录阡陌
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="pwd"></param>
        public string loginQianmo(string mail, string pwd)
        {
            //username=yu%40megatontrade.com&password=153037&remember=true
            mail = System.Web.HttpUtility.UrlEncode(mail);
            string data = "username=" + mail + "&password=" + pwd + "&remember=true";
            string s = PostData(qianmologinUrl, qianmoUrl, data);
            return s;//{"success": true}
        }

        /// <summary>
        /// 设置用户名
        /// </summary>
        /// <returns></returns>
        public bool setQianmoName(string name, CookieContainer cookiec)
        {
            //http://qianmo.com/settings/profile
            //display_name=%E5%8C%BF%E5%90%8D&interest=&bio=&birthday=&gender=0
            //返回网页
            name = System.Web.HttpUtility.UrlEncode(name);
            string data = "display_name=" + name + "&interest=&bio=&birthday=&gender=0";
            string s = PostData(qianmosetnameUrl, qianmoUrl, data, cookiec);
            if (s.Length < 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查用户名
        /// </summary>
        /// <returns></returns>
        public bool checkQianmoName(string name)
        {
            //http://qianmo.com/accounts/check_display_name
            //post
            //display_name=匿名
            //{"in_use": false}
            name = System.Web.HttpUtility.UrlEncode(name);
            string data = "display_name=" + name;
            string s = PostData(qianmocheckUrl, qianmoUrl, data);
            if (s.Contains("false"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public string getQianmoUser(CookieContainer cookiec)
        {
            //http://qianmo.com/api/v1/user
            //get
            //{"profile": {"website": null, "bio": null, "location_string": null, "orientation": null, "blood_group": null, "gender": 0, "image": "http://static.qianmo.com/image/noavatar.png", "tags": null, "cover": "http://static.qianmo.com/image/nocover.jpg", "astro": null, "audio_bio": null, "birthday": null, "location": null, "tag": null, "mood": null}, "activate": true, "description": {"text": ""}, "watched_time": 0, "stick_video": null, "follower": 0, "last_post_id": null, "likes": 0, "follow": 10, "watched": 0, "display_name": "\u7f8e\u56fd\u4e4b\u58f0", "alias": null, "post_count": 0, "posts": 0, "last_post_time": null, "url": "/u/3731", "like_count": 0, "flags": 0, "email": "yu@megatontrade.com", "fav_count": 0}
            return "";
        }

        /// <summary>
        /// 获取新邮箱
        /// </summary>
        /// <returns></returns>
        public string getNewMail()
        {
            //data=twrmai47081&type=renew&arg=d%3Dchacuo.net_f%3D&beforeSend=undefined
            //data=hnzdvu56418&type=renew&arg=d%3D027168.com_f%3D&beforeSend=undefined
            //data:hnzdvu56418
            //type:renew
            //arg:d=027168.com_f=
            //beforeSend:undefined
            //{"status":1,"info":"ok","data":["oiaxdk78603"]}
            string data = "data=twrmai47081&type=renew&arg=d%3Dchacuo.net_f%3D&beforeSend=undefined";
            cookiec.Add(new Uri("http://24mail.chacuo.net"), new Cookie("sid", "0ec67997abd099d86d6d065bc47e1617686d252a"));
            string s = PostData(randomMailUrl, randomMailUrl, data, cookiec);

            return s;
        }

        /// <summary>
        /// 检查激活邮件是否到位
        /// </summary>
        /// <returns></returns>
        public string checkMail(string mail)
        {
            //http://24mail.chacuo.net/enus
            //data=oiaxdk78603&type=refresh&arg=
            //data:oiaxdk78603
            //type:refresh
            //arg:
            //{"status":1,"info":"ok","data":[{"stat":{"refusemail":"84317920","sucmail":"80254514","20150506":0,"curmail":"35604","totalmail":164572434},"user":{"UID":"166686499","USER":"oiaxdk78603","STATUS":"1","ADDTIME":"2015-05-06 03:02:41","EXPIRETIME":"2015-05-07 03:02:41","IP":"122.225.33.12","NUM":"0","FORWARD":""},"list":[]}]}
            // {"status":1,"info":"ok","data":[{"stat":{"refusemail":"84317978","sucmail":"80255764","20150506":0,"curmail":"36912","totalmail":164573742},"user":{"UID":"166687597","USER":"nwupkq03961","STATUS":"1","ADDTIME":"2015-05-06 03:06:12","EXPIRETIME":"2015-05-07 03:06:12","IP":"122.225.33.12","NUM":"0","FORWARD":""},"list":[{"UID":166687597,"TO":"<nwupkq03961@027168.com>","PATCH":0,"ISREAD":0,"SENDTIME":"2015-05-06 03:06:51","FROM":"\u9621\u964c<no-reply@qianmo.com>","SUBJECT":"\u9621\u964c\u89c6\u9891\u793e\u533a\u6fc0\u6d3b\u90ae\u4ef6","MID":80239561,"SIZE":1765}]}]}
            string data = "data=" + mail + "&type=refresh&arg=";
            string s = PostData(randomMailUrl, randomMailUrl, data, cookiec);
            return s;
        }

        /// <summary>
        /// 获取邮件正文
        /// </summary>
        /// <returns></returns>
        public string getMail(string mail, string mid)
        {
            //            readmail
            //data=hrkxls39251&type=mailinfo&arg=f%3D80254099
            //data:nwupkq03961
            //type:mailinfo
            //arg:f=80239561
            //{"status":1,"info":"ok","data":[[{"MID":"80239561","UID":"166687597","SUBJECT":"\u9621\u964c\u89c6\u9891\u793e\u533a\u6fc0\u6d3b\u90ae\u4ef6","FROM":"\u9621\u964c<no-reply@qianmo.com>","TO":"<nwupkq03961@027168.com>","SENDTIME":"2015-05-06 03:06:51","SIZE":"1765","PATCH":"0","ISREAD":"0","RLINK":"http:\/\/tool.chacuo.net\/mailanonymous\/f_nwupkq03961@027168.com=t_no-reply@qianmo.com"},[{"ID":"80246893","MID":"80239561","NAME":"","DATA":["\u6b22\u8fce\u4f60\u6765\u5230\u9621\u964c\u89c6\u9891\u793e\u533a\uff01\n\u4e3a\u4e86\u7ef4\u62a4\u9621\u964c\u7684\u826f\u597d\u6c1b\u56f4\uff0c\u4fdd\u8bc1\u4f60\u7684\u6b63\u5e38\u4f53\u9a8c\uff0c\u8bf7\u70b9\u51fb\u4ee5\u4e0b\u94fe\u63a5\u6fc0\u6d3b\u8d26\u53f7\u3002\nhttps:\/\/qianmo.com\/confirm\/4a4bf0c7dc8c4e80a79b8799795cf916\n\uff08\u5982\u679c\u65e0\u6cd5\u70b9\u51fb\uff0c\u8bf7\u628a\u8fde\u63a5\u5b8c\u6574\u590d\u5236\u81f3\u5730\u5740\u680f\uff09\n\n\u6fc0\u6d3b\u94fe\u63a5\u4ec5\u572848\u5c0f\u65f6\u5185\u6709\u6548\uff0c\u5982\u679c\u60a8\u6ca1\u6709\u6ce8\u518c\u8d26\u53f7\uff0c\u8bf7\u5ffd\u7565\u672c\u90ae\u4ef6\u3002"],"TYPE":"0"}]]]}
            string data = "data=" + mail + "&type=mailinfo&arg=f%3D" + mid;
            string s = PostData(randomMailUrl, randomMailUrl, data, cookiec);
            return s;
        }

        /// <summary>
        /// 验证激活
        /// </summary>
        /// <param name="parsedmailUrl"></param>
        /// <returns></returns>
        public bool readMail(string parsedmailUrl)
        {
            if (getString(parsedmailUrl).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion - 方法 -
    }
}