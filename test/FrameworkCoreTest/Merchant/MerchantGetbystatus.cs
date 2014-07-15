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
    public class MerchantGetbystatus : MockPostApiBaseTest<MerchantGetbystatusRequest, MerchantGetbystatusResponse>
    {
        [Fact]
        public void MockMerchantGetBystatusTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(3, response.ProductInfos.Count());
        }

        protected override MerchantGetbystatusRequest InitRequestObject()
        {
            return new MerchantGetbystatusRequest
            {
                AccessToken = "123",
                Status = 0
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;

            var result = new
            {
                errcode = 0,
                errmsg = "success",
                products_info = new List<ProductInfo>
                {
                    GetProduct("1"),
                    GetProduct("2"),
                    GetProduct("3")
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(result));
            return JsonConvert.SerializeObject(result);
        }

        private ProductInfo GetProduct(string productId)
        {
            var product = new Product
            {

                Name = "test product 1",
                OriPrice = 999,
                MainImage = "http://image1.product1.jpg",
                BuyLimit = 1,
                Categories = new string[] { "530707078" },
                Properties = new List<ProductProperty> {
                    new ProductProperty{ VID = "107979797", ID = "121321"}
                },
                Detail = new List<ProductDetail> { 
                    new ProductDetail{ Text = "hello world"}
                },
                Images = new string[] { "http://img2.product1.jgp" },
                SkuInfos = new List<SkuInfo>
                {
                    new SkuInfo{ ID = "107575757", VID = new string[]{"2222", "3333"}}
                }
            };

            var skulist = new List<Sku>{
                new Sku{
                    SkuID = "1075741873:1079742386",
                    Price = 30,
                    IconUrl = "http://sku1icon.jpg",
                    ProductCode = "testing",
                    OriPrice = 90000,
                    Quantity = 10
                }
            };

            var attrext = new Attrext
            {
                IsPostFree = false,
                IsHasReceipt = true,
                IsSupportReplace = false,
                IsUnderGuaranty = false,
                Location = new Location
                {
                    Country = "中国",
                    City = "上海市",
                    Province = "上海市",
                    Address = "重庆南路"
                }
            };

            var delivery = new Delivery
            {
                DeliveryType = 1,
                TemplateID = 1
            };

            var productInfo = new ProductInfo
            {
                ProductBase = product,
                SkuList = skulist,
                Attrext = attrext,
                DeliveryInfo = delivery,
                ProductID = productId
            };

            return productInfo;
        }
    }
}
