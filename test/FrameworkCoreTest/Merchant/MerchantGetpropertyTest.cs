using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;
using WX.Model;
using Newtonsoft.Json;

namespace FrameworkCoreTest.Merchant
{
    public class MerchantGetpropertyTest : MockPostApiBaseTest<MerchantCategoryGetpropertyRequest, MerchantCategoryGetpropertyResponse>
    {
        [Fact]
        public void MerchantCategoryGetpropertySuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(1, response.Properties.Count());
        }

        protected override MerchantCategoryGetpropertyRequest InitRequestObject()
        {
            return new MerchantCategoryGetpropertyRequest
            {
                CateID = 123123123,
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            var result = new
            {
                errcode = 0,
                errmsg = "success",
                properties = new List<Property>
                {
                    new Property{
                        PropertyID = "107545189",
                        Name = "brand",
                        PropertyValues = new List<PropertyValue>{
                            new PropertyValue{ Id = "p1", Name = "p1"},
                            new PropertyValue{Id = "p2", Name = "p2"}
                        },
                    },
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(result));
            return JsonConvert.SerializeObject(result);
        }
    }
}
