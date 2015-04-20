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
    public class DatacubeGetInterfaceTest : MockPostApiBaseTest<DatacubeGetInterfaceSummaryHourRequest, DatacubeGetInterfaceResponse>
    {
        protected override DatacubeGetInterfaceSummaryHourRequest InitRequestObject()
        {
            return new DatacubeGetInterfaceSummaryHourRequest
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
                       ""ref_date"": ""2014-12-01"", 
                       ""ref_hour"": 0, 
                       ""callback_count"": 331, 
                       ""fail_count"": 18, 
                       ""total_time_cost"": 167870, 
                       ""max_time_cost"": 5042
                   }
	            //后续还有不同ref_hour的数据
               ]
            }";
        }

        public override DatacubeGetInterfaceResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }
    }
}
