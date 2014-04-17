using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class CnblogsArticleNewsMessageHandler : IMessageHandler
    {
        public ResponseMessage HandlerRequestMessage(MiddleMessage msg)
        {
            //var request = new RequestTextMessage(xml);
            var response = new ResponseNewsMessage(msg.RequestMessage);
            var cnblogsFeed = new CnBlogsFeed(5);
            var articles = cnblogsFeed.GetTopCnblogsFeed();
            response.ArticleCount = articles.Count;
            response.CreateTime = DateTime.Now.Ticks;
            response.Articles = articles;

            return response;
        }
    }
}
