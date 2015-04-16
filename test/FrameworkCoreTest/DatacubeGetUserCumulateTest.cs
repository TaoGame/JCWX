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
    public class DatacubeGetUserCumulateTest : MockPostApiBaseTest<DatacubeGetUserCumulateRequest, DatacubeGetUserCumulateResponse>
    {
        protected override DatacubeGetUserCumulateRequest InitRequestObject()
        {
            return new DatacubeGetUserCumulateRequest
            {
                AccessToken = "123",
                BeginDate = "2015-04-04",
                EndDate = "2015-04-07"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{ 
                    ""list"": [ 
                        { 
                            ""ref_date"": ""2014-12-07"", 
                            ""cumulate_user"": 1217056
                        }, 
	                //后续还有ref_date在begin_date和end_date之间的数据
                    ]
                }";
        }

        public override DatacubeGetUserCumulateResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
