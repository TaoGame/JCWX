using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Template
{
    public class TemplateSendTest : MockPostApiBaseTest<TemplateSendRequest, TemplateSendResponse>
    {

        [Fact]
        public void TemplateSend()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(200228332, response.MsgID);
        }

        protected override TemplateSendRequest InitRequestObject()
        {
            var data = new Dictionary<string, TemplateDataProperty>();

            data.Add("first", new TemplateDataProperty("恭喜你购买成功", "#173177"));
            data.Add("keynote1", new TemplateDataProperty("巧克力", "#173177"));
            data.Add("keynote2", new TemplateDataProperty("39.8元", "#173177"));
            data.Add("keynote3", new TemplateDataProperty("2014年9月16日", "#173177"));
            data.Add("remark", new TemplateDataProperty("欢迎再次购买！", "#173177"));
            return new TemplateSendRequest
            {
                AccessToken = "123",
                TemplateID = "ngqIpbwh8bUfcSsECmogfXcV14J0tQlEpBO27izEYtY",
                Url = "ngqIpbwh8bUfcSsECmogfXcV14J0tQlEpBO27izEYtY",
                TopColor = "#FF0000",
                Data = data,
                ToUser = "123xc"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{
                   ""errcode"":0,
                   ""errmsg"":""ok"",
                   ""msgid"":200228332
               }";
        }
    }
}
