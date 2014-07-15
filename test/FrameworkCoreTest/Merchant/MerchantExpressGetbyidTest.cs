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
    public class MerchantExpressGetbyidTest : MockPostApiBaseTest<MerchantExpressGetbyidRequest, MerchantExpressGetbyidResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(123456, response.TemplateInfo.ID);
            Assert.Equal("template 1", response.TemplateInfo.Name);
            Assert.Equal(3, response.TemplateInfo.TopFees.Count());
        }

        protected override MerchantExpressGetbyidRequest InitRequestObject()
        {
            return new MerchantExpressGetbyidRequest
            {
                AccessToken = "123",
                TemplateID = 123456
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            var result = new { 
                errcode = 0,
                errmsg = "success",
                template_info = new DeliveryTemplate
                {
                    ID = 123456,
                    Assumer = 0,
                    Name = "template 1",
                    Valuation = 0,
                    TopFees = new List<TopFee>
                    {
                        new TopFee{
                            FeeType = 10000027,
                            Normal = new NormalFee{
                                StartStandards = 1,
                                StartFees = 2,
                                AddStandards = 3,
                                AddFees = 1
                            },
                            Customs = new List<CustomFee>{
                                new CustomFee{
                                    StartStandards = 1,
                                    StartFees = 100,
                                    AddStandards = 1,
                                    AddFees = 3,
                                    DestCountry = "China",
                                    DestProvince = "Guang Dong Sheng",
                                    DestCity = "GuangZhou"
                                },
                            },
                        },
                        new TopFee{
                            FeeType = 10000028,
                            Normal = new NormalFee{
                                StartStandards = 1,
                                StartFees = 3,
                                AddStandards = 3,
                                AddFees = 2
                            },
                            Customs = new List<CustomFee>{
                                new CustomFee{
                                    StartStandards = 1,
                                    StartFees = 10,
                                    AddStandards = 1,
                                    AddFees = 30,
                                    DestCountry = "China",
                                    DestProvince = "Guang Dong Sheng",
                                    DestCity = "GuangZhou"
                                },
                            },
                        },
                        new TopFee{
                            FeeType = 10000029,
                            Normal = new NormalFee{
                                StartStandards = 1,
                                StartFees = 2,
                                AddStandards = 3,
                                AddFees = 1
                            },
                            Customs = new List<CustomFee>{
                                new CustomFee{
                                    StartStandards = 1,
                                    StartFees = 100,
                                    AddStandards = 1,
                                    AddFees = 3,
                                    DestCountry = "China",
                                    DestProvince = "Guang Dong Sheng",
                                    DestCity = "GuangZhou"
                                },
                            },
                        },
                    }
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(result));

            return JsonConvert.SerializeObject(result);
        }
    }
}
