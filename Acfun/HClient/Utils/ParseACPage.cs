using System;
using System.Windows.Forms;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;

namespace HClient.Utils
{
    internal class ParseACPage
    {
        public string[] parseWebPage(string url, string postNo)
        {
            var uri = new Uri(url);
            var browser1 = new ScrapingBrowser();
            string html1 = null;
            try
            {
                html1 = browser1.DownloadString(uri);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html1);
            var html = htmlDocument.DocumentNode;
            System.Collections.Generic.IEnumerable<HtmlNode> divs = html.CssSelect("div.threads_" + postNo + " a");
            int i = 0;
            foreach (var htmlNode in divs)
            {
                if (htmlNode.FirstChild.OuterHtml.Contains("img"))
                {
                    i++;
                }
            }
            string[] tempImgURL = new string[i];
            int j = 0;
            foreach (var htmlNode in divs)
            {
                if (htmlNode.FirstChild.OuterHtml.Contains("img"))
                {
                    string[] temparray = htmlNode.FirstChild.OuterHtml.Split('"');
                    tempImgURL[j] = temparray[1].Replace("thumb", "image");
                    tempImgURL[j] = tempImgURL[j].Replace("/th/", "/images/");
                    Console.WriteLine(htmlNode.InnerHtml);
                    j++;
                }
            }
            return tempImgURL;
        }

        public int parseWebPageNo(string url, string postNo)
        {
            int pageCount = 1;
            var uri = new Uri(url);
            var browser1 = new ScrapingBrowser();
            string html1 = "";
            try
            {
                html1 = browser1.DownloadString(uri);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html1);
            var html = htmlDocument.DocumentNode;
            System.Collections.Generic.IEnumerable<HtmlNode> aLinks = html.CssSelect("a");
            string finalLink = "";
            foreach (var htmlNode in aLinks)
            {
                if (htmlNode.OuterHtml.Contains(postNo + "?page="))
                {
                    //<a href="/t/4480216?page=6">末页</a>

                    finalLink = htmlNode.OuterHtml;
                }
            }
            if (finalLink != "")
            {
                string temp = "";
                temp = finalLink.Substring(finalLink.IndexOf("?") + 6, 3);
                if (temp.Contains(">"))
                {
                    temp.Remove(1);
                }
                else if (temp.Contains("\""))
                {
                    temp = temp.ToCharArray(0, 3)[0].ToString() + temp.ToCharArray(0, 3)[1].ToString();
                }
                pageCount = Convert.ToInt32(temp);
            }
            return pageCount;
        }
    }
}