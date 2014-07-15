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
    public class MerchantShelfAddTest : MockPostApiBaseTest<MerchantShelfAddRequest, MerchantShelfAddResponse>
    {
        [Fact]
        public void MerchantShelfAddPostContentTest()
        {
            var request = InitRequestObject();

            Console.WriteLine(request.GetPostContent());
        }

        protected override MerchantShelfAddRequest InitRequestObject()
        {
            var request = new MerchantShelfAddRequest()
            {
                ShelfBanner = "http//img1.sh-bus.com/banner.jpg",
                ShelfName = "test shelf"
            };

            var one = new ShelfModuleOne(50, 2);
            var two = new ShelfModuleTwo(new long[] { 49, 50, 51, 52 });
            var three = new ShelfModuleThree(52, "http://img1.sh-bus.com/three.jpg");
            var four = new ShelfModuleFour(new List<ShelfGroupInfo>() { 
                new ShelfGroupInfo{
                    GroupID = 49,
                    Img = "http://img1.sh-bus.com/49.jpg"
                },
                new ShelfGroupInfo{
                    GroupID = 50,
                    Img = "http://img1.sh-bus.com/50.jpg"
                }
            });
            var five = new ShelfModuleFive(new long[] { 49, 50, 51, 52, 53 }, "http://img.sh-bus.com/backup.jpg");

            request.AddModules(one, two, three, four);

            return request;
        }

        protected override string GetReturnResult(bool errResult)
        {
            throw new NotImplementedException();
        }
    }
}
