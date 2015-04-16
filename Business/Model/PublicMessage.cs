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
}
