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
    public class MerchantExpressGetallTest : MockPostApiBaseTest<MerchantExpressGetallRequest, MerchantExpressGetallResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(3, response.Templates.Count());
        }

        [Fact]
        public override void MockGetPostContent()
        {
            Assert.Throws(typeof(NotImplementedException), () => base.MockGetPostContent());
        }

        protected override MerchantExpressGetallRequest InitRequestObject()
        {
            return new MerchantExpressGetallRequest
            {
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            var result = new { 
                errcode = 0,
                errmsg = "success",
                templates_info = new List<DeliveryTemplate>
                {
                    GetTemplate(1),
                    GetTemplate(2),
                    GetTemplate(3)
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(result));

            return JsonConvert.SerializeObject(result);
        }

        private DeliveryTemplate GetTemplate(long id)
        {
            return new DeliveryTemplate
                {
                    ID = id,
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
                };
        }
    }
}
