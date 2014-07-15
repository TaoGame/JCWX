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
    public class MerchantUpdateTest : MockPostApiBaseTest<MerchantUpdateRequest, DefaultResponse>
    {
        [Fact]
        public void MockGetPostContent()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        [Fact]
        public void MockUpdateTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
        }

        protected override MerchantUpdateRequest InitRequestObject()
        {
            return new MerchantUpdateRequest
            {
                ProductInfo = GetProduct(),
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            return errResult ? s_errmsg : s_successmsg;
        }

        private ProductInfo GetProduct()
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
                ProductID = "123456789"
            };

            return productInfo;
        }
    }
}
