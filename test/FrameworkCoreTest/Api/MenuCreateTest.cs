using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using WX.Model;
using WX.Framework;

namespace FrameworkCoreTest
{
    public class MenuCreateTest : MockPostApiBaseTest<MenuCreateRequest, MenuCreateResponse>
    {
        [Fact]
        public void MenuCreatePostContentTest()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        [Fact]
        public void MockMenuCreateTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(false, response.IsError);
            Assert.Equal("ok", response.ErrorMessage);
        }
        [Fact]
        public void MockMenuCreateErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
        }

        [Fact]
        public void ReallyMenuCreateTest()
        {
            var request = new MenuCreateRequest
            {
                AccessToken = GetCurrentToken(),
                Buttons = new List<ClickButton>
                {
                    new ClickButton{
                        Name = "博客",
                        Url = "http://inday.cnblogs.com",
                        Type = ClickButtonType.view
                    },

                    new ClickButton{
                        Name = "文章",
                        SubButton = new List<ClickButton>{
                            new ClickButton{
                                Name = "推荐",
                                Url = "http://www.cnblogs.com",
                                Type = ClickButtonType.view
                            },
                            new ClickButton {
                                Name = "精华",
                                Url = "http://www.cnblogs.com/pick/",
                                Type = ClickButtonType.view
                            }
                        }
                    },

                    new ClickButton{
                        Name = "新闻",
                        Url="http://www.cnblogs.com/news/",
                        Type = ClickButtonType.view
                    },
                }
            };
            var response = m_client.Execute(request);
            if (response.IsError)
            {
                Console.WriteLine(response);
            }
            else
            {
                Assert.Equal(false, response.IsError);
                Assert.Equal("ok", response.ErrorMessage);
            }
        }

        protected override MenuCreateRequest InitRequestObject()
        {
            return new MenuCreateRequest
            {
                AccessToken = GetCurrentToken(),
                Buttons = new List<ClickButton>
                {
                    new ClickButton{
                        Name = "博客",
                        Url = "http://inday.cnblogs.com",
                        Type = ClickButtonType.view
                    },

                    new ClickButton{
                        Name = "文章",
                        SubButton = new List<ClickButton>{
                            new ClickButton{
                                Name = "推荐",
                                Url = "http://www.cnblogs.com",
                                Type = ClickButtonType.view
                            },
                            new ClickButton {
                                Name = "精华",
                                Url = "http://www.cnblogs.com/pick/",
                                Type = ClickButtonType.view
                            }
                        }
                    },

                    new ClickButton{
                        Name = "新闻",
                        Url="http://www.cnblogs.com/news/",
                        Type = ClickButtonType.view
                    },
                }
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return "{\"errcode\":40018,\"errmsg\":\"invalid button name size\"}";
            return "{\"errcode\":0,\"errmsg\":\"ok\"}";
        }
    }
}
