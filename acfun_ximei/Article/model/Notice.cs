using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Article.baseUtils
{
    public class Notice
    {
        public string[] special { get; set; }
        public int newPush { get; set; }
        public int newFollowed { get; set; }
        public bool success { get; set; }
        public string[] bangumi { get; set; }
        public int unReadMail { get; set; }
        public int mention { get; set; }
    }
}
