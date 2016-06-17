using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace Article.Model
{
    internal class User
    {
        //http://www.acfun.tv/usercard.aspx?uid=461174
        //http://www.acfun.tv/usercard.aspx?username=%E9%B8%A1%E5%85%AB%E5%B2%81%E4%BA%86
        //{"userjson":{"currExp":3346,"stows":0,"comments":0,"gender":-1,"level":24,"sign":"前天看到了小兔子，昨天是小鹿，今天是........","follows":9,"lastLoginDate":"2015-04-27 18:09:54.0","avatar":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201304/09090036jj4d.jpg","posts":0,"followed":0,"lastLoginIp":"112.224.67.*","fans":4,"uid":461174,"regTime":"2013-01-09 09:20:28.0","nextLevelNeed":3800,"comeFrom":"","name":"一之濑小琴美","dTime":"","expPercent":24,"isFriend":0,"views":0},"success":true}
        //{"userjson":{"currExp":550,"stows":0,"comments":0,"gender":0,"level":50,"sign":"咯咯哒~心爱的干妹妹的鸡，八岁了哦！","follows":10,"lastLoginDate":"2015-04-28 13:57:40.0","avatar":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201505/10144418391r.jpg","posts":0,"followed":0,"lastLoginIp":"222.242.43.*","fans":15,"uid":1236910,"regTime":"2015-03-27 14:37:01.0","nextLevelNeed":600,"comeFrom":"湖北,不限","name":"鸡八岁了","dTime":"","expPercent":50,"isFriend":0,"views":0},"success":true}

        public User getModelFromJson(string json)
        {
            JsonSchema schema = new JsonSchema();
            schema.Type = JsonSchemaType.Object;
            JObject jsonObj = JObject.Parse(json);
            if (!jsonObj.IsValid(schema))
            {
                return null;
            }
            JArray jar = JArray.Parse(jsonObj["userjson"].ToString());
            string temp = jar[0].ToString().Replace("'", "");
            User user = (User)JsonConvert.DeserializeObject(temp, typeof(User));
            return user;
        }

        private String currExp;

        private String stows;

        private String comments;

        private String gender;

        private String level;

        private String sign;

        private String follows;

        private String lastLoginDate;

        private String avatar;

        private String posts;

        private String followed;

        private String lastLoginIp;

        private String fans;

        private String uid;

        private String regTime;

        private String nextLevelNeed;

        private String comeFrom;

        private String name;

        private String dTime;

        private String expPercent;

        private String isFriend;

        private String views;

        public void setCurrExp(String currExp)
        {
            this.currExp = currExp;
        }

        public String getCurrExp()
        {
            return this.currExp;
        }

        public void setStows(String stows)
        {
            this.stows = stows;
        }

        public String getStows()
        {
            return this.stows;
        }

        public void setComments(String comments)
        {
            this.comments = comments;
        }

        public String getComments()
        {
            return this.comments;
        }

        public void setGender(String gender)
        {
            this.gender = gender;
        }

        public String getGender()
        {
            return this.gender;
        }

        public void setLevel(String level)
        {
            this.level = level;
        }

        public String getLevel()
        {
            return this.level;
        }

        public void setSign(String sign)
        {
            this.sign = sign;
        }

        public String getSign()
        {
            return this.sign;
        }

        public void setFollows(String follows)
        {
            this.follows = follows;
        }

        public String getFollows()
        {
            return this.follows;
        }

        public void setLastLoginDate(String lastLoginDate)
        {
            this.lastLoginDate = lastLoginDate;
        }

        public String getLastLoginDate()
        {
            return this.lastLoginDate;
        }

        public void setAvatar(String avatar)
        {
            this.avatar = avatar;
        }

        public String getAvatar()
        {
            return this.avatar;
        }

        public void setPosts(String posts)
        {
            this.posts = posts;
        }

        public String getPosts()
        {
            return this.posts;
        }

        public void setFollowed(String followed)
        {
            this.followed = followed;
        }

        public String getFollowed()
        {
            return this.followed;
        }

        public void setLastLoginIp(String lastLoginIp)
        {
            this.lastLoginIp = lastLoginIp;
        }

        public String getLastLoginIp()
        {
            return this.lastLoginIp;
        }

        public void setFans(String fans)
        {
            this.fans = fans;
        }

        public String getFans()
        {
            return this.fans;
        }

        public void setUid(String uid)
        {
            this.uid = uid;
        }

        public String getUid()
        {
            return this.uid;
        }

        public void setRegTime(String regTime)
        {
            this.regTime = regTime;
        }

        public String getRegTime()
        {
            return this.regTime;
        }

        public void setNextLevelNeed(String nextLevelNeed)
        {
            this.nextLevelNeed = nextLevelNeed;
        }

        public String getNextLevelNeed()
        {
            return this.nextLevelNeed;
        }

        public void setComeFrom(String comeFrom)
        {
            this.comeFrom = comeFrom;
        }

        public String getComeFrom()
        {
            return this.comeFrom;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void setDTime(String dTime)
        {
            this.dTime = dTime;
        }

        public String getDTime()
        {
            return this.dTime;
        }

        public void setExpPercent(String expPercent)
        {
            this.expPercent = expPercent;
        }

        public String getExpPercent()
        {
            return this.expPercent;
        }

        public void setIsFriend(String isFriend)
        {
            this.isFriend = isFriend;
        }

        public String getIsFriend()
        {
            return this.isFriend;
        }

        public void setViews(String views)
        {
            this.views = views;
        }

        public String getViews()
        {
            return this.views;
        }
    }
}