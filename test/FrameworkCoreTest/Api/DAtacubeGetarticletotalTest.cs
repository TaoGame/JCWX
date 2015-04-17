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
    public class DatacubeGetarticletotalTest : MockPostApiBaseTest<DatacubeGetarticletotalRequest, DatacubeGetArticlesResponse>
    {
        protected override DatacubeGetarticletotalRequest InitRequestObject()
        {
            return new DatacubeGetarticletotalRequest
            {
                AccessToken = "123",
                BeginDate = "2015-04-01",
                EndDate = "2015-04-16"
            };
        }

        public override DatacubeGetArticlesResponse GetResponse()
        {
            return mock_client.Object.Execute(Request);
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return @"{ 
               ""list"": [ 
                   { 
                       ""ref_date"": ""2014-12-14"", 
                       ""msgid"": ""202457380_1"", 
                       ""title"": ""马航丢画记"", 
                       ""details"": [ 
                           { 
                               ""stat_date"": ""2014-12-14"", 
                               ""target_user"": 261917, 
                               ""int_page_read_user"": 23676, 
                               ""int_page_read_count"": 25615, 
                               ""ori_page_read_user"": 29, 
                               ""ori_page_read_count"": 34, 
                               ""share_user"": 122, 
                               ""share_count"": 994, 
                               ""add_to_fav_user"": 1, 
                               ""add_to_fav_count"": 3
                           }, 
	            //后续还会列出所有stat_date符合“ref_date（群发的日期）到接口调用日期”（但最多只统计7天）的数据
                       ]
                   },
	            //后续还有ref_date（群发的日期）在begin_date和end_date之间的群发文章的数据
               ]
            }";
        }
    }
}
