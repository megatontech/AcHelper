using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Article.Model
{
    public class Article
    {
        //请求地址
        //http://api.acfun.tv/apiserver/content/channel?cd=1&channelId=110&pageNo=1&pageSize=20&recommendSize=6&origin=h5&_=1431253913302&name=sanae
        //system.tv={"success":true,"msg":"查询成功","status":200,"data":{"page":{"pageNo":1,"pageSize":20,"totalCount":93552,"orderBy":0,"list":[{"user":{"userId":549621,"username":"时空探索者ъ","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201505/07190840ssc0.jpg"},"tags":[],"description":"来源：bBlizzard Watch作者：雜草","contentId":1887368,"isArticle":1,"channelId":110,"releaseDate":1431253019000,"title":"WOW:小电球的小历史：扯一扯电盾的过去与现在","isRecommend":0,"views":178,"comments":4,"stows":2,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-night.png","viewOnly":0},{"user":{"userId":549621,"username":"时空探索者ъ","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201505/07190840ssc0.jpg"},"tags":[],"description":"来源：wowhead作者：多玩整理","contentId":1887359,"isArticle":1,"channelId":110,"releaseDate":1431252886000,"title":"WOW:6.2PTR：击杀精英BOSS可掉落3个新坐骑","isRecommend":0,"views":279,"comments":8,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-night.png","viewOnly":0},{"user":{"userId":1280555,"username":"不是随便的人","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/261313203dum.jpg"},"tags":[],"description":"去年中国网络广告收入1500亿元 首超电视广告","contentId":1887308,"isArticle":1,"channelId":110,"releaseDate":1431251119000,"title":"去年中国网络广告收入1500亿元 首超电视广告","isRecommend":0,"views":938,"comments":35,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":1280555,"username":"不是随便的人","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/261313203dum.jpg"},"tags":[],"description":"外媒：南非红酒包装仿法国货 增加在中国销量","contentId":1887306,"isArticle":1,"channelId":110,"releaseDate":1431251070000,"title":"外媒：南非红酒包装仿法国货 增加在中国销量","isRecommend":0,"views":345,"comments":10,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":1280555,"username":"不是随便的人","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/261313203dum.jpg"},"tags":[],"description":"孟加拉国举办“汉语桥”大学生中文比赛","contentId":1887302,"isArticle":1,"channelId":110,"releaseDate":1431250867000,"title":"孟加拉国举办“汉语桥”大学生中文比赛","isRecommend":0,"views":212,"comments":3,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"澳推出男士超性感内衣 开辟新天地","contentId":1887284,"isArticle":1,"channelId":110,"releaseDate":1431250636000,"title":"澳推出男士超性感内衣 开辟新天地","isRecommend":0,"views":2346,"comments":43,"stows":1,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"盘点国外独特又奇葩的母亲节礼物","contentId":1887282,"isArticle":1,"channelId":110,"releaseDate":1431250479000,"title":"盘点国外独特又奇葩的母亲节礼物","isRecommend":0,"views":662,"comments":20,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":1225482,"username":"浮生愿不曾解","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/09203329p6px.jpg"},"tags":[],"description":"研究人员认为,麻疹疫苗让接种者免得麻疹,保持了免疫系统“记忆”完整,因此会在一定程度上提供对其他感染的保护。","contentId":1887234,"isArticle":1,"channelId":110,"releaseDate":1431249116000,"title":"科学家发现接种麻疹疫苗还可降低其他传染病的感染风险","isRecommend":0,"views":424,"comments":14,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"情侣住酒店被困卫生间 花40多分钟砸洞逃出","contentId":1887174,"isArticle":1,"channelId":110,"releaseDate":1431247444000,"title":"情侣住酒店被困卫生间 花40多分钟砸洞逃出","isRecommend":0,"views":7608,"comments":100,"stows":3,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"巴西44名囚犯一天内分批越狱","contentId":1887172,"isArticle":1,"channelId":110,"releaseDate":1431247397000,"title":"巴西44名囚犯一天内分批越狱","isRecommend":0,"views":2258,"comments":34,"stows":1,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"中美女孩闺房大PK 美国女孩闺房内穿着暴露","contentId":1887159,"isArticle":1,"channelId":110,"releaseDate":1431247026000,"title":"中美女孩闺房大PK 美国女孩闺房内穿着暴露","isRecommend":0,"views":11025,"comments":117,"stows":9,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":1311250,"username":"我来了，别急啊！","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/2601063177fp.jpg"},"tags":[],"description":"南京一幼童手卡旋转门 消防队火速排险","contentId":1887144,"isArticle":1,"channelId":110,"releaseDate":1431245632000,"title":"南京一幼童手卡旋转门 消防队火速排险","isRecommend":0,"views":2621,"comments":50,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":835995,"username":"张理行","userImg":"http://static.acfun.mm111.net/dotnet/20120923/style/image/avatar.jpg"},"tags":[],"description":"最任性的发明：激光打蚊子","contentId":1887142,"isArticle":1,"channelId":110,"releaseDate":1431245534000,"title":"最任性的发明：激光打蚊子","isRecommend":0,"views":11228,"comments":150,"stows":16,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":1280555,"username":"不是随便的人","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201504/261313203dum.jpg"},"tags":[],"description":"外国留学生：“毕业旅行”乘高铁参观中国新农村很特别","contentId":1887137,"isArticle":1,"channelId":110,"releaseDate":1431245384000,"title":"外国留学生：“毕业旅行”乘高铁参观中国新农村很特别","isRecommend":0,"views":7927,"comments":73,"stows":2,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"美国两名警察遭枪杀警车被抢 警方正追捕嫌犯","contentId":1887136,"isArticle":1,"channelId":110,"releaseDate":1431245365000,"title":"美国两名警察遭枪杀警车被抢 警方正追捕嫌犯","isRecommend":0,"views":3871,"comments":74,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"奇妙抓拍：那些被“惊呆”的小动物","contentId":1887134,"isArticle":1,"channelId":110,"releaseDate":1431245288000,"title":"奇妙抓拍：那些被“惊呆”的小动物","isRecommend":0,"views":6324,"comments":73,"stows":40,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"“剩女”发999个帖子寻找男神：再不疯狂就老了","contentId":1887126,"isArticle":1,"channelId":110,"releaseDate":1431245123000,"title":"“剩女”发999个帖子寻找男神：再不疯狂就老了","isRecommend":0,"views":9437,"comments":142,"stows":4,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"组图：美军士兵寄给母亲礼物迟到73年后抵达","contentId":1887115,"isArticle":1,"channelId":110,"releaseDate":1431244752000,"title":"组图：美军士兵寄给母亲礼物迟到73年后抵达","isRecommend":0,"views":4451,"comments":43,"stows":3,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"美教师在学生手臂烙印被捕 学生集体为其求情","contentId":1887108,"isArticle":1,"channelId":110,"releaseDate":1431244437000,"title":"美教师在学生手臂烙印被捕 学生集体为其求情","isRecommend":0,"views":3420,"comments":42,"stows":0,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0},{"user":{"userId":390011,"username":"梦斩千钧","userImg":"http://static.acfun.mm111.net/dotnet/artemis/u/cms/www/201404/19220659fesv.jpg"},"tags":[],"description":"广西举办校花校草大赛 因“颜值低”被吐槽","contentId":1887106,"isArticle":1,"channelId":110,"releaseDate":1431244395000,"title":"广西举办校花校草大赛 因“颜值低”被吐槽","isRecommend":0,"views":13948,"comments":224,"stows":3,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover-day.png","viewOnly":0}]}}}
        //http://api.acfun.tv/apiserver/content/info?contentId=1887142
        //返回数据格式
        //{"success":true,"msg":"操作成功","status":200,"data":{"fullArticle":{"user":{"userId":835995,"username":"张理行","userImg":"http://static.acfun.mm111.net/dotnet/20120923/style/image/avatar.jpg"},"tags":["打蚊子"],"txt":"<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>\r\n<p class=\"detailPic\"><img width=\"550\" height=\"321\" alt=\"\" src=\"http://y2.ifengimg.com/haina/2015_20/e1b6bcd82945c2c.undefined\" /></p>\r\n<p class=\"picIntro\" style=\"text-align: left;\"><span><span style=\"font-family: 宋体;\">用激光打蚊子不仅获得了盖茨基金会的赞助，还入选了《时代》周刊的五十大最佳发明榜单。这种新工具包括一把微型激光炮，全自动击发，三十米范围内百发百中。面对这样一台灭蚊神器，你心动了吗？</span></span></p>\r\n<p>今天科学咖向小伙伴介绍一个任性的发明：用激光打蚊子。是不是脑海里立刻浮现出《星球大战》之类的科幻片了？是的，这个发明的最初构想正是来源于美国政府几十年前提出的&ldquo;星球大战&rdquo;计划。从打飞船变成打蚊子，可谓是人类的幸运与蚊子的不幸。目前，打蚊子激光器正准备投入商业生产，也许再过几年，每到蚊虫肆虐的炎炎夏日，我们就可以端个小板凳坐在激光器旁，欣赏一出&ldquo;星球大战&rdquo;的大片了~~~~</p>\r\n<p class=\"detailPic\"><img alt=\"\" src=\"http://y1.ifengimg.com/haina/2015_20/bba90b6fef6c8ee.undefined\" /></p>\r\n<p class=\"picIntro\" style=\"text-align: left;\"><span><span style=\"font-family: 宋体;\">这种小型激光炮，能够在一秒钟之内消灭数十只蚊子，而不会伤及其他生物。这种&ldquo;自动防御装置&rdquo;的基本构成并不十分复杂，所有硬件基本上都可以在市场上买到。所需的部件包括几个红外发光二极管、数码相机的CCD（电荷耦合器件）传感器、光驱或者蓝光DVD播放机里的激光器、一些透镜、拥有一定程度计算能力的硬件和软件，以及一些用于路标和隔离带的逆反射材料&mdash;&mdash;这种材料能够把光线沿着入射方向反射回去。把它们组装在一起，就能造出一部微型蚊子防御系统了。</span></span></p>\r\n<p class=\"picIntro\" style=\"text-align: left;\"><span><span style=\"font-family: 宋体;\">机器工作的原理嘛，是先发出低能量无害的红外探测激光，并由反光板反射回来，组成一道探测用的&ldquo;光墙&rdquo;。当蚊子触碰到&ldquo;光墙&rdquo;时，由激光器立刻再发出一道激光到蚊子身上，通过尺寸与翅膀振动频率确认是蚊子，并且空间无障碍物。随后，立刻发射高能的攻击性激光，将蚊子击落。</span></span></p>\r\n<p>科学咖画了一张图，呵呵，大家凑合着看吧</p>\r\n<p class=\"detailPic\"><img alt=\"\" src=\"http://y3.ifengimg.com/haina/2015_20/c43e79b8383ed6e.undefined\" /></p>\r\n<p class=\"picIntro\" style=\"text-align: left;\"><span><span style=\"font-family: 宋体;\">激光武器不像高射炮那样需要测距之后再发射，而和光速比起来，飞行中的蚊子就像悬在空中的雕像一样稳定，不会打偏。而且，杀灭蚊子这样的小昆虫并不需要太高的能量，也就避免了误伤其他动物或者人的可能。最重要的，是它对环境完全不会产生危害。</span></span></p>\r\n<p>目前这种激光炮的有效距离大概是30米，激光器的旋转范围为22度，如果大量生产的话，成本将会降到50美元以下。小伙伴们，面对这样一台灭蚊神器，你们心动了吗？</p>\r\n<p>&nbsp;</p>","description":"最任性的发明：激光打蚊子","contentId":1887142,"isArticle":1,"channelId":110,"releaseDate":1431245534000,"title":"最任性的发明：激光打蚊子","isRecommend":0,"views":4429,"comments":72,"stows":7,"toplevel":0,"cover":"http://static.acfun.mm111.net/dotnet/20120923/style/image/cover.png","viewOnly":0}}}

        public Article getModelFromJson(string json)
        {
            JObject jsonObj = JObject.Parse(json);
            JArray jar = JArray.Parse(jsonObj["fullArticle"].ToString());
            string temp = jar[0].ToString().Replace("'", "");
            Article article = (Article)JsonConvert.DeserializeObject(temp, typeof(Article));
            return article;
        }

        private String user;

        private List<tags> tagss;

        private String txt;

        private String description;

        private String contentId;

        private String isArticle;

        private String channelId;

        private String releaseDate;

        private String title;

        private String isRecommend;

        private String views;

        private String comments;

        private String stows;

        private String toplevel;

        private String cover;

        private String viewOnly;

        public void setUser(String user)
        {
            this.user = user;
        }

        public String getUser()
        {
            return this.user;
        }

        public void setTags(List<tags> tags)
        {
            this.tagss = tags;
        }

        public List<tags> getTags()
        {
            return this.tagss;
        }

        public void setTxt(String txt)
        {
            this.txt = txt;
        }

        public String getTxt()
        {
            return this.txt;
        }

        public void setDescription(String description)
        {
            this.description = description;
        }

        public String getDescription()
        {
            return this.description;
        }

        public void setContentId(String contentId)
        {
            this.contentId = contentId;
        }

        public String getContentId()
        {
            return this.contentId;
        }

        public void setIsArticle(String isArticle)
        {
            this.isArticle = isArticle;
        }

        public String getIsArticle()
        {
            return this.isArticle;
        }

        public void setChannelId(String channelId)
        {
            this.channelId = channelId;
        }

        public String getChannelId()
        {
            return this.channelId;
        }

        public void setReleaseDate(String releaseDate)
        {
            this.releaseDate = releaseDate;
        }

        public String getReleaseDate()
        {
            return this.releaseDate;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public String getTitle()
        {
            return this.title;
        }

        public void setIsRecommend(String isRecommend)
        {
            this.isRecommend = isRecommend;
        }

        public String getIsRecommend()
        {
            return this.isRecommend;
        }

        public void setViews(String views)
        {
            this.views = views;
        }

        public String getViews()
        {
            return this.views;
        }

        public void setComments(String comments)
        {
            this.comments = comments;
        }

        public String getComments()
        {
            return this.comments;
        }

        public void setStows(String stows)
        {
            this.stows = stows;
        }

        public String getStows()
        {
            return this.stows;
        }

        public void setToplevel(String toplevel)
        {
            this.toplevel = toplevel;
        }

        public String getToplevel()
        {
            return this.toplevel;
        }

        public void setCover(String cover)
        {
            this.cover = cover;
        }

        public String getCover()
        {
            return this.cover;
        }

        public void setViewOnly(String viewOnly)
        {
            this.viewOnly = viewOnly;
        }

        public String getViewOnly()
        {
            return this.viewOnly;
        }
    }

    public class tags
    {
        private string tagName;

        public string TagName
        {
            get { return tagName; }
            set { tagName = value; }
        }
    }

    public class RootArticle
    {
        private String success;

        private String msg;

        private String status;

        private DataArticle data;

        public void setSuccess(String success)
        {
            this.success = success;
        }

        public String getSuccess()
        {
            return this.success;
        }

        public void setMsg(String msg)
        {
            this.msg = msg;
        }

        public String getMsg()
        {
            return this.msg;
        }

        public void setStatus(String status)
        {
            this.status = status;
        }

        public String getStatus()
        {
            return this.status;
        }

        public void setData(DataArticle data)
        {
            this.data = data;
        }

        public DataArticle getData()
        {
            return this.data;
        }
    }

    public class DataArticle
    {
        private string page;

        public void setPage(string page)
        {
            this.page = page;
        }

        public string getPage()
        {
            return this.page;
        }
    }

    public class PageArticle
    {
        private String pageNo;

        private String pageSize;

        private String totalCount;

        private String orderBy;

        private List<string> lists;

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

        public void setOrderBy(String orderBy)
        {
            this.orderBy = orderBy;
        }

        public String getOrderBy()
        {
            return this.orderBy;
        }

        public void setList(List<String> list)
        {
            this.lists = list;
        }

        public List<String> getList()
        {
            return this.lists;
        }
    }
}