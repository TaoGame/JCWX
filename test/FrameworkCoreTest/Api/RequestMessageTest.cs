using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WX.Model;
using Xunit;

namespace FrameworkCoreTest
{
    public class RequestMessageTest
    {
        [Fact]
        public void VoiceRequestMessageTest()
        {
            var xml = @"<xml>
                          <ToUserName><![CDATA[gh_4efbac7d38cc]]></ToUserName>
                        <FromUserName><![CDATA[oI1_vjirqEuoDttmL-eRcsO-G9to]]></FromUserName>
                        <CreateTime>1400120855</CreateTime>
                        <MsgType><![CDATA[voice]]></MsgType>
                        <MediaId><![CDATA[RXS7f4w1cns6KTMEeVRa46i0q7f8TM57Gr_c2AnOSrKfzE1GqB7q1zYhpj_xVVKf]]></MediaId>
                        <Format><![CDATA[amr]]></Format>
                        <MsgId>6013473282672558080</MsgId>
                        <Recognition><![CDATA[我可怜不可怜博客园]]></Recognition>
                        </xml>";
            var doc = XDocument.Parse(xml);
            var midder = new MiddleMessage(doc.Element("xml"));
            var request = midder.RequestMessage as RequestVoiceMessage;
            if (request != null)
            {
                Console.WriteLine(request.Recognition);
            }
        }
    }
}
