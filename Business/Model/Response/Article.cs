using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WX.Model
{
    public class Article
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
}
