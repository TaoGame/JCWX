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
}
