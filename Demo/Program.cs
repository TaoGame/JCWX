using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WX.Business;
using WX.Model;

namespace TestConsole
{
    public class Person
    {



        public int Age { get; set; }

        [XmlIgnore]
        public string Name { get; set; }

        [XmlElement("Name")]
        public XmlCDataSection CName
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                return doc.CreateCDataSection(Name);
            }
            set
            {
                Name = value.Value;
            }
        }

        public string Sex { get { return "nan"; } }

        [XmlElement("Sex")]
        public string ShowSex
        {
            get { return Sex; }
            set { ;}
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region test

            //input info
            var request = new RequestTextMessage
            {
                ToUserName = "sh_bus",
                FromUserName = "jamesying1",
                MsgId = 123123123L,
                CreateTime = 1231231322L,
                Content = "my request message"
            };

            StringWriter sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RequestTextMessage));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(sw, request, ns);
            Console.WriteLine(sw.ToString());
            Stream stream = new MemoryStream(sw.Encoding.GetBytes(sw.ToString()));

            //get request message

            #endregion
            var reader = XmlReader.Create(stream);
            var doc = XDocument.Load(reader);
            var xml = doc.Element("xml");
            IMessageRole role = new MyMessageRole();
            IMessageHandler handler = role.MessageRole(xml);
            ResponseMessage response = handler.HandlerRequestMessage(xml);
            if (response != null)
            {
                Console.WriteLine(response.Serializable());
            }
            else
            {
                Console.WriteLine("not handler");
            }
            Console.Read();
        }
    }
}
