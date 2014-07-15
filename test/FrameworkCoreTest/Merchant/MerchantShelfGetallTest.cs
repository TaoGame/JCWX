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
    public class MerchantShelfGetallTest : MockPostApiBaseTest<MerchantShelfGetallRequest, MerchantShelfGetallResponse>
    {
        [Fact]
        public void MockSuccess()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal(2, response.Shelves.Count());
            var first = response.Shelves.FirstOrDefault();
            Assert.Equal(1, first.ShelfInfos.Modules.Count());
            foreach (var shelf in response.Shelves)
            {
                Console.WriteLine("name:{0}", shelf.Name);
                Console.WriteLine("id:{0}", shelf.ShelfID);
                foreach (var module in shelf.ShelfInfos.Modules)
                {
                    Console.WriteLine("module is module {0}", module.EID);
                }
            }
        }

        protected override MerchantShelfGetallRequest InitRequestObject()
        {
            return new MerchantShelfGetallRequest
            {
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult) return s_errmsg;
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

            var obj = new
            {
                errcode = 0,
                errmsg = "success",
                shelves = new List<ShelfInfo>
                {
                    new ShelfInfo{
                        Banner = "banner",
                        Name = "shelf 1",
                        ShelfID = 123,
                        ShelfInfos = new ShelfModulesInfo{
                            Modules = new List<ShelfModule>{
                                new ShelfModuleFive(
                                    new long[]{2000080093, 2000080094, 2000080095},
                                    "imgbackgournd.jpg"
                                    )
                            },
                        }
                    },
                    new ShelfInfo{
                        Banner = "banner 2",
                        Name = "shelf 2",
                        ShelfID = 234,
                        ShelfInfos = new ShelfModulesInfo(new List<ShelfModule>{one, two, three, four})
                    }
                }
            };

            var result = JsonSerialize(obj);
            Console.WriteLine(result);

            return result;
        }
    }
}
