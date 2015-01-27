using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Template
{
    public class TemplateSetindustrayTest : MockPostApiBaseTest<TemplateApisetindustryRequest, DefaultResponse>
    {
        [Fact]
        public void GetPostContentTest()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        protected override TemplateApisetindustryRequest InitRequestObject()
        {
            return new TemplateApisetindustryRequest
            {
                Industry_id1 = WX.Model.TemplateIndustry.Travel,
                Industry_id2 = WX.Model.TemplateIndustry.Hotel,
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            throw new NotImplementedException();
        }
    }
}
