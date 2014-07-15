using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest
{
    public class CustomeServiceGetRecordTest : MockPostApiBaseTest<CustomServiceGetRecordRequest, CustomServiceGetRecordResponse>
    {
        [Fact]
        public void MockCustomServiceGetRecordTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(this.Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(2, response.RecordList.Count());
            foreach (var r in response.RecordList)
            {
                Console.WriteLine("{0}:{1}", r.Worker, r.Text);
            }
        }

        [Fact]
        public void MockCustomServiceGetRecordErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(this.Request);
            Assert.Equal(true, response.IsError);
            Console.WriteLine(response.ToString());
        }

        protected override CustomServiceGetRecordRequest InitRequestObject()
        {
            return new CustomServiceGetRecordRequest
            {
                StartTime = new DateTime(2014,1,1),
                EndTime = new DateTime(2014,3,1),
                AccessToken = "123",
                OpenId = "123",
                PageIndex = 1,
                PageSize = 10
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40029,\"errmsg\":\"invalid code\"}";
            }

            return @"{
                ""recordlist"": [
                    {
                        ""worker"": "" test1"",
                        ""openid"": ""oDF3iY9WMaswOPWjCIp_f3Bnpljk"",
                        ""opercode"": 2002,
                        ""time"": 1400563710,
                        ""text"": "" 您好，客服test1为您服务。""
                    },
                    {
                        ""worker"": "" test1"",
                        ""openid"": ""oDF3iY9WMaswOPWjCIp_f3Bnpljk"",
                        ""opercode"": 2003,
                        ""time"": 1400563731,
                        ""text"": "" 你好，有什么事情？ ""
                    },
                ]
            }";
        }
    }
}
