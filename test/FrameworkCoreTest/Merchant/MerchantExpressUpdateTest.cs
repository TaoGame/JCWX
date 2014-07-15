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
    public class MerchantExpressUpdateTest : MockPostApiBaseTest<MerchantExpressUpdateRequest, DefaultResponse>
    {
        [Fact]
        public void Success()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }

        protected override MerchantExpressUpdateRequest InitRequestObject()
        {
            return new MerchantExpressUpdateRequest
            {
                TemplateID = 123456,
                AccessToken = "123",
                DeliveryTemplate = new WX.Model.DeliveryTemplate
                {
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
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }
    }
}
