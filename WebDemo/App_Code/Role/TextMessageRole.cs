using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using WX.Business;
using WX.Model;
namespace WebDemo.App_Code
{
    public class TextMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(MiddleMessage msg)
        {
            var request = (RequestTextMessage)msg.RequestMessage;

            if (request.Content.IndexOf("博客园文章") > -1)
            {
                return new CnblogsArticleNewsMessageHandler();
            }

            if (request.Content.IndexOf("博客园") > -1)
            {
                return new CnblogsTextMessageHandler();
            }

            return new DefaultMessageHandler();
        }
    }
}