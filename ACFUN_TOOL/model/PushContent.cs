using System;

namespace Article.model
{
    /// <summary>
    /// 推送分页
    /// </summary>
    public class page
    {
        private String pageNo;

        private String pageSize;

        private String totalCount;

        private String totalPage;

        private String prePage;

        private String nextPage;

        public void setPageNo(String pageNo)
        {
            this.pageNo = pageNo;
        }

        public String getPageNo()
        {
            return this.pageNo;
        }

        public void setPageSize(String pageSize)
        {
            this.pageSize = pageSize;
        }

        public String getPageSize()
        {
            return this.pageSize;
        }

        public void setTotalCount(String totalCount)
        {
            this.totalCount = totalCount;
        }

        public String getTotalCount()
        {
            return this.totalCount;
        }

        public void setTotalPage(String totalPage)
        {
            this.totalPage = totalPage;
        }

        public String getTotalPage()
        {
            return this.totalPage;
        }

        public void setPrePage(String prePage)
        {
            this.prePage = prePage;
        }

        public String getPrePage()
        {
            return this.prePage;
        }

        public void setNextPage(String nextPage)
        {
            this.nextPage = nextPage;
        }

        public String getNextPage()
        {
            return this.nextPage;
        }
    }

    /// <summary>
    /// 推送内容
    /// </summary>
    public class contents
    {
        private String username;

        private String userId;

        private String userImg;

        private String avatar;

        private String sign;

        private String aid;

        private String cid;

        private String title;

        private String titleImg;

        private String url;

        private String releaseDate;

        private String description;

        private String channelId;

        private String tags;

        private String contentClass;

        private String author;

        private String allowDanmaku;

        private String views;

        private String stows;

        private String comments;

        private String score;

        private String time;

        private String isArticle;

        private String success;

        private String errorlog;

        public void setUsername(String username)
        {
            this.username = username;
        }

        public String getUsername()
        {
            return this.username;
        }

        public void setUserId(String userId)
        {
            this.userId = userId;
        }

        public String getUserId()
        {
            return this.userId;
        }

        public void setUserImg(String userImg)
        {
            this.userImg = userImg;
        }

        public String getUserImg()
        {
            return this.userImg;
        }

        public void setAvatar(String avatar)
        {
            this.avatar = avatar;
        }

        public String getAvatar()
        {
            return this.avatar;
        }

        public void setSign(String sign)
        {
            this.sign = sign;
        }

        public String getSign()
        {
            return this.sign;
        }

        public void setAid(String aid)
        {
            this.aid = aid;
        }

        public String getAid()
        {
            return this.aid;
        }

        public void setCid(String cid)
        {
            this.cid = cid;
        }

        public String getCid()
        {
            return this.cid;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public String getTitle()
        {
            return this.title;
        }

        public void setTitleImg(String titleImg)
        {
            this.titleImg = titleImg;
        }

        public String getTitleImg()
        {
            return this.titleImg;
        }

        public void setUrl(String url)
        {
            this.url = url;
        }

        public String getUrl()
        {
            return this.url;
        }

        public void setReleaseDate(String releaseDate)
        {
            this.releaseDate = releaseDate;
        }

        public String getReleaseDate()
        {
            return this.releaseDate;
        }

        public void setDescription(String description)
        {
            this.description = description;
        }

        public String getDescription()
        {
            return this.description;
        }

        public void setChannelId(String channelId)
        {
            this.channelId = channelId;
        }

        public String getChannelId()
        {
            return this.channelId;
        }

        public void setTags(String tags)
        {
            this.tags = tags;
        }

        public String getTags()
        {
            return this.tags;
        }

        public void setContentClass(String contentClass)
        {
            this.contentClass = contentClass;
        }

        public String getContentClass()
        {
            return this.contentClass;
        }

        public void setAuthor(String author)
        {
            this.author = author;
        }

        public String getAuthor()
        {
            return this.author;
        }

        public void setAllowDanmaku(String allowDanmaku)
        {
            this.allowDanmaku = allowDanmaku;
        }

        public String getAllowDanmaku()
        {
            return this.allowDanmaku;
        }

        public void setViews(String views)
        {
            this.views = views;
        }

        public String getViews()
        {
            return this.views;
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

        public void setScore(String score)
        {
            this.score = score;
        }

        public String getScore()
        {
            return this.score;
        }

        public void setTime(String time)
        {
            this.time = time;
        }

        public String getTime()
        {
            return this.time;
        }

        public void setIsArticle(String isArticle)
        {
            this.isArticle = isArticle;
        }

        public String getIsArticle()
        {
            return this.isArticle;
        }

        public void setSuccess(String success)
        {
            this.success = success;
        }

        public String getSuccess()
        {
            return this.success;
        }

        public void setErrorlog(String errorlog)
        {
            this.errorlog = errorlog;
        }

        public String getErrorlog()
        {
            return this.errorlog;
        }
    }

    /// <summary>
    /// 评论
    /// </summary>
    public class Comment
    {
        //根据文章id获取评论json
        //http://www.acfun.tv/comment_list_json.aspx?contentId=1830542&currentPage=1
        //根据json数据totalPage数量循环获取所有分页评论
        //分离每条评论，转换评论内容中的链接和图片，转换文字和表情[emot\u003dac,08/]，转换反白[color\u003d#ffffff]这里是反白[/color]
        //设置盖楼
        //存档每个用户的评论
        private String cid;

        private String content;

        private String userName;

        private String userID;

        private String postDate;

        private String userImg;

        private String quoteId;

        private String count;

        private String ups;

        private String downs;

        public void setCid(String cid)
        {
            this.cid = cid;
        }

        public String getCid()
        {
            return this.cid;
        }

        public void setContent(String content)
        {
            this.content = content;
        }

        public String getContent()
        {
            return this.content;
        }

        public void setUserName(String userName)
        {
            this.userName = userName;
        }

        public String getUserName()
        {
            return this.userName;
        }

        public void setUserID(String userID)
        {
            this.userID = userID;
        }

        public String getUserID()
        {
            return this.userID;
        }

        public void setPostDate(String postDate)
        {
            this.postDate = postDate;
        }

        public String getPostDate()
        {
            return this.postDate;
        }

        public void setUserImg(String userImg)
        {
            this.userImg = userImg;
        }

        public String getUserImg()
        {
            return this.userImg;
        }

        public void setQuoteId(String quoteId)
        {
            this.quoteId = quoteId;
        }

        public String getQuoteId()
        {
            return this.quoteId;
        }

        public void setCount(String count)
        {
            this.count = count;
        }

        public String getCount()
        {
            return this.count;
        }

        public void setUps(String ups)
        {
            this.ups = ups;
        }

        public String getUps()
        {
            return this.ups;
        }

        public void setDowns(String downs)
        {
            this.downs = downs;
        }

        public String getDowns()
        {
            return this.downs;
        }
    }
}