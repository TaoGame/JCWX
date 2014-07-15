using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest.Merchant
{
    public class MerchantOrderGetbyidTest : MockPostApiBaseTest<MerchantOrderGetbyidRequest, MerchantOrderGetbyidResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal("7197417460812533543", response.Order.OrderID);
            Assert.Equal(1394635817, response.Order.CreateTime);
            Assert.Equal("pDF3iYx7KDQVGzB8kDg6Tge50kFo", response.Order.ProductID);
            Assert.Equal(5, response.Order.ExpressPrice);
        }

        protected override MerchantOrderGetbyidRequest InitRequestObject()
        {
            return new MerchantOrderGetbyidRequest
            {
                AccessToken = "123",
                OrderID = "7197417460812584720"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
            return JsonSerialize(new
            {
                errcode = 0,
                errmsg = "success",
                order = new
                {
                    order_id = "7197417460812533543",
                    order_status = 6,
                    order_total_price = 6,
                    order_create_time = 1394635817,
                    order_express_price = 5,
                    buyer_openid = "0DF3iY17NsDAW4UP2qzJXPsz1S9Q",
                    buyer_nick = "likeacat",
                    receiver_name = "zhang xiao mao",
                    receiver_province = "guangdongsheng",
                    receiver_city = "guangzhoushi",
                    receiver_address = "huajingluyihao",
                    receiver_mobile = "123456789",
                    receiver_phone = "123456789",
                    product_id = "pDF3iYx7KDQVGzB8kDg6Tge50kFo",
                    product_name = "anlifang e-bar jlajsdkfj",
                    product_price = 1,
                    product_sku = "10000983:10000995;10001007:10001010",
                    product_count = 1,
                    product_img = "http://img2.paipaiimg.com/0000000/item-5232.jpg",
                    delivery_id = "19006597372473",
                    delivery_company = "059Yunda",
                    trans_id = "1900000109201404103172199813"
                }
            });
        }
    }
}
