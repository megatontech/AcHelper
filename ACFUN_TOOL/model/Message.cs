using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Article.Model
{
    internal class Message
    {
        //http://www.acfun.tv/member/unRead.aspx?uid=1005273
        //{"special":[],"newPush":7,"newFollowed":0,"success":true,"bangumi":[],"unReadMail":0,"mention":0}

        public Message getModelFromJson(string json)
        {
            Message msg = (Message)JsonConvert.DeserializeObject(json, typeof(Message));
            return msg;
        }

        private List<special> specials;

        private String newPush;

        private String newFollowed;

        private String success;

        private List<bangumi> bangumis;

        private String unReadMail;

        private String mention;

        public void setSpecial(List<special> special)
        {
            this.specials = special;
        }

        public List<special> getSpecial()
        {
            return this.specials;
        }

        public void setNewPush(String newPush)
        {
            this.newPush = newPush;
        }

        public String getNewPush()
        {
            return this.newPush;
        }

        public void setNewFollowed(String newFollowed)
        {
            this.newFollowed = newFollowed;
        }

        public String getNewFollowed()
        {
            return this.newFollowed;
        }

        public void setSuccess(String success)
        {
            this.success = success;
        }

        public String getSuccess()
        {
            return this.success;
        }

        public void setBangumi(List<bangumi> bangumi)
        {
            this.bangumis = bangumi;
        }

        public List<bangumi> getBangumi()
        {
            return this.bangumis;
        }

        public void setUnReadMail(String unReadMail)
        {
            this.unReadMail = unReadMail;
        }

        public String getUnReadMail()
        {
            return this.unReadMail;
        }

        public void setMention(String mention)
        {
            this.mention = mention;
        }

        public String getMention()
        {
            return this.mention;
        }
    }

    public class special
    {
        private string specialName;

        public string SpecialName
        {
            get { return specialName; }
            set { specialName = value; }
        }
    }

    public class bangumi
    {
        private string bangumiName;

        public string BangumiName
        {
            get { return bangumiName; }
            set { bangumiName = value; }
        }
    }
}