using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Merchant
{
    public class MerchantCategoryGetskuTest : MockPostApiBaseTest<MerchantCategoryGetskuRequest, MerchantCategoryGetskuResponse>
    {
        [Fact]
        public void MerchantCategoryGetskuSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(2, response.SkuTables.Count());
        }

        protected override MerchantCategoryGetskuRequest InitRequestObject()
        {
            return new MerchantCategoryGetskuRequest
            {
                AccessToken = "123",
                CateID = 123123
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            var result = new
            {
                errcode = 0,
                errmsg = "success",
                sku_table = new List<SkuTable>
                {
                    new SkuTable{
                        SkuTableID = "1111", 
                        Name = "1111", 
                        ValueList = new List<SkuValue>{
                            new SkuValue{ Id = "value1", Name = "value1"},
                            new SkuValue{Id = "value2", Name = "value2"}
                        }
                    },
                     new SkuTable{
                        SkuTableID = "2222", 
                        Name = "2222", 
                        ValueList = new List<SkuValue>{
                            new SkuValue{ Id = "value3", Name = "value3"},
                            new SkuValue{Id = "value4", Name = "value4"}
                        }
                    },
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(result));
            return JsonConvert.SerializeObject(result);
        }
    }
}
