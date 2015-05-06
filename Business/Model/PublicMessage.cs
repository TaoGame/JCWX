using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WX.Model
{
    public class TextMessage
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class ImageMessage
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }

    public class MusicMessage
    {
        [JsonProperty("title",
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description",
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// 感谢C#-古道-广州发现的bug
        /// </summary>
        [JsonProperty("musicurl")]
        public string MusicUrl { get; set; }

        [JsonProperty("hqmusicurl")]
        public string HQMusicUrl { get; set; }

        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }


    public class VideoMessage
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("title",
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description",
            DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public class VoiceMessage
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }

    public class NewsMessage
    {
        [JsonProperty("articles")]
        public IEnumerable<NewsArticleMessage> Articles { get; set; }
    }

    public class NewsArticleMessage
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("picurl")]
        public string PicUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class ArticleMessage
    {
        protected XmlDocument doc = new XmlDocument();

        [XmlIgnore]
        [JsonProperty("title")]
        public string Title { get; set; }

        [XmlIgnore]
        [JsonProperty("digest")]
        public string Description { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public string PicUrl { get; set; }

        [XmlIgnore]
        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        [XmlIgnore]
        [JsonProperty("content_source_url")]
        public string Url { get; set; }

        [XmlIgnore]
        [JsonProperty("content")]
        public string Content { get; set; }

        [XmlIgnore]
        [JsonProperty("author")]
        public string Author { get; set; }

        [XmlElement("Title")]
        [JsonIgnore]
        public XmlCDataSection CTitle
        {
            get
            {
                return doc.CreateCDataSection(Title);
            }
            set
            {
                Title = value.Value;
            }
        }

        [XmlElement("Description")]
        [JsonIgnore]
        public XmlCDataSection CDescription
        {
            get
            {
                return doc.CreateCDataSection(Description);
            }
            set
            {
                Description = value.Value;
            }
        }

        [XmlElement("PicUrl")]
        [JsonIgnore]
        public XmlCDataSection CPicUrl
        {
            get
            {
                return doc.CreateCDataSection(PicUrl);
            }
            set
            {
                PicUrl = value.Value;
            }
        }

        [XmlElement("Url")]
        [JsonIgnore]
        public XmlCDataSection CUrl
        {
            get
            {
                return doc.CreateCDataSection(Url);
            }
            set
            {
                Url = value.Value;
            }
        }
    }

    public class CustomServiceRecord
    {
        public string Worker { get; set; }

        public string OpenId { get; set; }

        public int Opercode { get; set; }

        public long Time { get; set; }

        public string Text { get; set; }
    }

    public class AutoReplyInfo
    {
        /// <summary>
        /// 自动回复的类型。关注后自动回复和消息自动回复的类型仅支持文本（text）、图片（img）、语音（voice）、视频（video），关键词自动回复则还多了图文消息
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// 对于文本类型，content是文本内容，对于图片、语音、视频类型，content是mediaID
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    /// <summary>
    /// 匹配的关键词信息
    /// </summary>
    public class KeywordReplyInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 匹配模式，contain代表消息中含有该关键词即可
        /// </summary>
        [JsonProperty("match_mode")]
        public string MatchMode { get; set; }
    }

    public class NewsInfo
    {
        [JsonProperty("list")]
        public IEnumerable<KeywordReplyNews> List { get; set; }
    }

    public class KeywordReplyNews
    {
        /// <summary>
        /// 图文消息的标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        [JsonProperty("digest")]
        public string Digest { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// 是否显示封面，0为不显示，1为显示
        /// </summary>
        [JsonProperty("show_cover")]
        public int ShowConver { get; set; }

        /// <summary>
        /// 封面图片的URL
        /// </summary>
        [JsonProperty("cover_url")]
        public string ConverUrl { get; set; }

        /// <summary>
        /// 正文的URL
        /// </summary>
        [JsonProperty("content_url")]
        public string ContentUrl { get; set; }

        /// <summary>
        /// 原文的URL，若置空则无查看原文入口
        /// </summary>
        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class KeywordRule
    {
        [JsonProperty("rule_name")]
        public string RuleName { get; set; }

        [JsonProperty("create_time")]
        public long CreateTime { get; set; }

        [JsonProperty("reply_mode")]
        public string ReplyMode { get; set; }

        [JsonProperty("keyword_list_info")]
        public IEnumerable<KeywordReplyInfo> KeywordListInfo { get; set; }

        [JsonProperty("reply_list_info")]
        public IEnumerable<KeywordReplyNews> ReplyListInfo { get; set; }
    }

    public class KeywordAutoreplyInfo
    {
        [JsonProperty("list")]
        public IEnumerable<KeywordRule> List { get; set; }
    }

    public class SelfMenuInfo
    {
        [JsonProperty("button")]
        public IEnumerable<ClickMenuInfo> Buttons { get; set; }
    }

    public class ClickMenuInfo
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("news_info")]
        public NewsInfo NewsInfo { get; set; }

        [JsonProperty("sub_button", NullValueHandling = NullValueHandling.Ignore)]
        public SubButton SubButton { get; set; }
    }

    public class SubButton
    {
        [JsonProperty("list")]
        public IEnumerable<ClickMenuInfo> Buttons { get; set; }
    }

    /// <summary>
    /// 用户统计数据
    /// </summary>
    public class UserDatacube
    {
        /// <summary>
        /// 数据的日期
        /// </summary>
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        /// <summary>
        /// 用户的渠道，数值代表的含义如下：
        ///0代表其他 30代表扫二维码 17代表名片分享 35代表搜号码（即微信添加朋友页的搜索） 39代表查询微信公众帐号 43代表图文页右上角菜单
        /// </summary>
        [JsonProperty("user_source")]
        public int UserSource { get; set; }

        /// <summary>
        /// 新增的用户数量
        /// </summary>
        [JsonProperty("new_user")]
        public int NewUser { get; set; }

        /// <summary>
        /// 取消关注的用户数量，new_user减去cancel_user即为净增用户数量
        /// </summary>
        [JsonProperty("cancel_user")]
        public int CanelUser { get; set; }

        /// <summary>
        /// 总用户量
        /// </summary>
        [JsonProperty("cumulate_user")]
        public int CumulateUser { get; set; }
    }

    /// <summary>
    /// 图文统计数据
    /// </summary>
    public class DatacubeArticle
    {
        /// <summary>
        /// 数据的日期，需在begin_date和end_date之间
        /// </summary>
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        /// <summary>
        /// 数据的小时，包括从000到2300，分别代表的是[000,100)到[2300,2400)，即每日的第1小时和最后1小时
        /// </summary>
        [JsonProperty("ref_hour")]
        public int RefHour { get; set; }

        /// <summary>
        /// 统计的日期，在getarticletotal接口中，ref_date指的是文章群发出日期， 而stat_date是数据统计日期
        /// </summary>
        [JsonProperty("stat_date")]
        public string StatDate { get; set; }

        /// <summary>
        /// 这里的msgid实际上是由msgid（图文消息id）和index（消息次序索引）组成， 例如12003_3， 其中12003是msgid，即一次群发的id消息的； 3为index，假设该次群发的图文消息共5个文章（因为可能为多图文）， 3表示5个中的第3个
        /// </summary>
        [JsonProperty("msgid")]
        public string MsgId { get; set; }

        /// <summary>
        /// 图文消息的标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 图文页（点击群发图文卡片进入的页面）的阅读人数
        /// </summary>
        [JsonProperty("int_page_read_user")]
        public int IntPageReadUser { get; set; }

        /// <summary>
        /// 图文页的阅读次数
        /// </summary>
        [JsonProperty("int_page_read_count")]
        public int IntPageReadCount { get; set; }

        /// <summary>
        /// 原文页（点击图文页“阅读原文”进入的页面）的阅读人数，无原文页时此处数据为0
        /// </summary>
        [JsonProperty("ori_page_read_user")]
        public int OriPageReadUser { get; set; }

        /// <summary>
        /// 原文页的阅读次数
        /// </summary>
        [JsonProperty("ori_page_read_count")]
        public int OriPageReadCount { get; set; }

        /// <summary>
        /// 分享的场景 
        /// 1代表好友转发 2代表朋友圈 3代表腾讯微博 255代表其他
        /// </summary>
        [JsonProperty("share_scene")]
        public int ShareScene { get; set; }

        /// <summary>
        /// 分享的人数
        /// </summary>
        [JsonProperty("share_user")]
        public int ShareUser { get; set; }

        /// <summary>
        /// 分享的次数
        /// </summary>
        [JsonProperty("share_count")]
        public int ShareCount { get; set; }

        /// <summary>
        /// 收藏的人数
        /// </summary>
        [JsonProperty("add_to_fav_user")]
        public int AddToFavUser { get; set; }

        /// <summary>
        /// 收藏的次数
        /// </summary>
        [JsonProperty("add_to_fav_count")]
        public int AddToFavCount { get; set; }

        /// <summary>
        /// 送达人数，一般约等于总粉丝数（需排除黑名单或其他异常情况下无法收到消息的粉丝）
        /// </summary>
        [JsonProperty("target_user")]
        public int TargetUser { get; set; }
    }

    public class DatacubeMsg
    {
        /// <summary>
        /// 数据的日期，需在begin_date和end_date之间
        /// </summary>
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        /// <summary>
        /// 数据的小时，包括从000到2300，分别代表的是[000,100)到[2300,2400)，即每日的第1小时和最后1小时
        /// </summary>
        [JsonProperty("ref_hour")]
        public int RefHour { get; set; }

        /// <summary>
        /// 消息类型，代表含义如下：
        /// 1代表文字 2代表图片 3代表语音 4代表视频 6代表第三方应用消息（链接消息）
        /// </summary>
        [JsonProperty("msg_type")]
        public int MsgType { get; set; }

        /// <summary>
        /// 上行发送了（向公众号发送了）消息的用户数 
        /// </summary>
        [JsonProperty("msg_user")]
        public int MsgUser { get; set; }

        /// <summary>
        /// 上行发送了消息的消息总数
        /// </summary>
        [JsonProperty("msg_count")]
        public int MsgCount { get; set; }

        /// <summary>
        /// 当日发送消息量分布的区间，0代表 “0”，1代表“1-5”，2代表“6-10”，3代表“10次以上”
        /// </summary>
        [JsonProperty("count_interval")]
        public int CountInterval { get; set; }

        /// <summary>
        /// 图文页的阅读次数
        /// </summary>
        [JsonProperty("int_page_read_count")]
        public int IntPageReadCount { get; set; }

        /// <summary>
        /// 原文页（点击图文页“阅读原文”进入的页面）的阅读人数，无原文页时此处数据为0
        /// </summary>
        [JsonProperty("ori_page_read_user")]
        public int OriPageReadUser { get; set; }
    }

    public class DatacubeInterface
    {
        /// <summary>
        /// 数据的日期，需在begin_date和end_date之间
        /// </summary>
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        /// <summary>
        /// 数据的小时，包括从000到2300，分别代表的是[000,100)到[2300,2400)，即每日的第1小时和最后1小时
        /// </summary>
        [JsonProperty("ref_hour")]
        public int RefHour { get; set; }

        /// <summary>
        /// 通过服务器配置地址获得消息后，被动回复用户消息的次数
        /// </summary>
        [JsonProperty("callback_count")]
        public int CallbackCount { get; set; }

        /// <summary>
        /// 上述动作的失败次数
        /// </summary>
        [JsonProperty("fail_count")]
        public int FailCount { get; set; }

        /// <summary>
        /// 总耗时，除以callback_count即为平均耗时
        /// </summary>
        [JsonProperty("total_time_cost")]
        public long TotalTimeCost { get; set; }

        /// <summary>
        /// 最大耗时
        /// </summary>
        [JsonProperty("max_time_cost")]
        public long MaxTimeCost { get; set; }
    }

    public class MaterialNews
    {

        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// 图文消息的封面图片素材id（必须是永久mediaID）
        /// </summary>
        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }

        /// <summary>
        /// 图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空
        /// </summary>
        [JsonProperty("digest")]
        public string Digest { get; set; }

        /// <summary>
        /// 是否显示封面，0为false，即不显示，1为true，即显示
        /// </summary>
        [JsonProperty("show_cover_pic")]
        public string ShowCoverPic { get; set; }
        /// <summary>
        /// 图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 图文消息的原文地址，即点击“阅读原文”后的URL
        /// </summary>
        [JsonProperty("content_source_url")]
        public string ContentSourceUrl { get; set; }
    }


    public class KfSession
    {
        /// <summary>
        /// 正在接待的客服，为空表示没有人在接待
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 会话接入的时间
        /// </summary>
        [JsonProperty("createtime")]
        public long Createtime { get; set; }
    }

    public class WaitCase
    {
        /// <summary>
        /// 客户openid
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 正在接待的客服，为空表示没有人在接待
        /// </summary>
        [JsonProperty("kf_account")]
        public string KfAccount { get; set; }

        /// <summary>
        /// 会话接入的时间
        /// </summary>
        [JsonProperty("createtime")]
        public long Createtime { get; set; }
    }
}
