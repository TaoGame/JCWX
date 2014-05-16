using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Demo.WebClasses.Handlers;
using WX.Framework;
using WX.Model;

namespace WX.Demo.WebClasses.Roles
{
    public class VoiceMessageRole : IMessageRole
    {
        public IMessageHandler MessageRole(MiddleMessage message)
        {
            var request = message.RequestMessage as RequestVoiceMessage;
            if (request != null)
            {
                //sMyLog.Log("语音识别：" + request.Recognition);
                if (!String.IsNullOrEmpty(request.Recognition))
                {
                    if (request.Recognition.IndexOf("博客园文章") > -1)
                    {
                        return new CnblogsArticleNewsMessageHandler();
                    }

                    if (request.Recognition.IndexOf("博客园") > -1)
                    {
                        return new CnblogsTextMessageHandler();
                    }

                    return new DefaultMessageHandler();
                }
                else
                {
                    return new VoiceMessageHandler();
                }
            }
            else
            {
                return new DefaultMessageHandler();
            }
        }
    }
}
