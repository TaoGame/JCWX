using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest
{
    public class MenuGetTest : MockPostApiBaseTest<MenuGetRequest, MenuGetResponse>
    {
        [Fact]
        public void MockMenuGetTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            foreach (var button in response.Menu.Buttons)
            {
                Console.WriteLine(button.Name);
                foreach (var sub in button.SubButton)
                {
                    Console.WriteLine("sub : " + sub.Name);
                }
            }
        }

        protected override MenuGetRequest InitRequestObject()
        {
            return new MenuGetRequest
            {
                AccessToken = "123"
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
            {
                return "{\"errcode\":40018,\"errmsg\":\"invalid button name size\"}";
            }
            return @"{""menu"":{""button"":[{""type"":""click"",""name"":""今日歌曲"",""key"":""V1001_TODAY_MUSIC"",""sub_button"":[]},{""type"":""click"",""name"":""歌手简介"",""key"":""V1001_TODAY_SINGER"",""sub_button"":[]},{""name"":""菜单"",""sub_button"":[{""type"":""view"",""name"":""搜索"",""url"":""http://www.soso.com/"",""sub_button"":[]},{""type"":""view"",""name"":""视频"",""url"":""http://v.qq.com/"",""sub_button"":[]},{""type"":""click"",""name"":""赞一下我们"",""key"":""V1001_GOOD"",""sub_button"":[]}]}]}}";
        }
    }
}
