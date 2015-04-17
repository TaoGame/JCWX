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
    public class DatacubeGetarticlesummaryTest : MockPostApiBaseTest<DatacubeGetarticlesummaryRequest, DatacubeGetArticlesResponse>
    {
        protected override DatacubeGetarticlesummaryRequest InitRequestObject()
        {
            return new DatacubeGetarticlesummaryRequest
            {
                AccessToken = "123",
                BeginDate = "2015-04-14",
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
                        ""ref_date"": ""2014-12-08"", 
                        ""msgid"": ""10000050_1"", 
                        ""title"": ""12月27日 DiLi日报"", 
                        ""int_page_read_user"": 23676, 
                        ""int_page_read_count"": 25615, 
                        ""ori_page_read_user"": 29, 
                        ""ori_page_read_count"": 34, 
                        ""share_user"": 122, 
                        ""share_count"": 994, 
                        ""add_to_fav_user"": 1, 
                        ""add_to_fav_count"": 3
                    } 
 	             //后续会列出该日期内所有被阅读过的文章（仅包括群发的文章）在当天的阅读次数等数据
                ]
            }";
        }
    }
}
