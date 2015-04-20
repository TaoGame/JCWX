using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Api
{
    public class DatacubeGetUpStreamMsgTest : MockPostApiBaseTest<DatacubeGetUpStreamMsgRequest,DatacubeGetStreamMsgResponse>
    {
        protected override DatacubeGetUpStreamMsgRequest InitRequestObject()
        {
            return new DatacubeGetUpStreamMsgRequest
            {
                AccessToken = "123",
                BeginDate = "2015-04-12",
                EndDate = "2015-04-13"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{ 
               ""list"": [ 
                   { 
                       ""ref_date"": ""2014-12-07"", 
                       ""msg_type"": 1, 
                       ""msg_user"": 282, 
                       ""msg_count"": 817
                   }
	            //后续还有同一ref_date的不同msg_type的数据，以及不同ref_date（在时间范围内）的数据
               ]
            }";
        }

        public override DatacubeGetStreamMsgResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
