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
        public string Title { get; set; }

        [XmlIgnore]
        public string Description { get; set; }

        [XmlIgnore]
        public string PicUrl { get; set; }

        [XmlIgnore]
        public string Url { get; set; }

        [XmlElement("Title")]
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
