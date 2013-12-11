using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Business;
using WX.Model;

namespace TestConsole.HandlerMessage
{
    public class NewsMessageHandler : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(XElement xml)
        {
            var request = new RequestTextMessage(xml);
            var response = new ResponseNewsMessage(request)
            {
                CreateTime = DateTime.Now.Ticks
            };
            var articles = new List<Article>
            {
                new Article{
                    Title = "article 1",
                    Description = "this is book",
                    PicUrl = "http://www.sh-bu.somc",
                    Url = "http://www.sh-bus.com"
                },
                new Article{
                    Title = "article 2",
                    Description = "this is book",
                    PicUrl = "http://www.sh-bu.somc",
                    Url = "http://www.sh-bus.com"
                },
            };

            response.ArticleCount = articles.Count;
            response.Articles = articles;
            return response;
        }
    }
}
