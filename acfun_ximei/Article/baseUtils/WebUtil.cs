using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web;

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

        public string loginUrl = "http://www.acfun.tv/login.aspx";

        public string checkinUrl = "http://www.acfun.tv/member/checkin.aspx";

        public string getpushUrl = "http://www.acfun.tv/member/unRead.aspx";

        public string getPublishUrl = "http://www.acfun.tv/member/publishContent.aspx?isGroup=0&groupId=-1&pageSize=10&pageNo=1";

        public CookieContainer cookiec = new CookieContainer();

        #endregion

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

        #endregion

        #region - 方法 -

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
                throw;
            }
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
                myHttpWebRequest.Timeout = 10000;
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

        public string throwBanana(string acNo,string userId,CookieContainer cookiec) 
        {
            string s = "";
            string data = "contentId=" + acNo + "&count=5&userId=" + userId;
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
                myHttpWebRequest.Timeout = 10000;
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
                myHttpWebRequest.Timeout = 10000;
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
            catch(Exception)
            {
               // throw;
            }
            return strResult;
        }

        #endregion

    }
}