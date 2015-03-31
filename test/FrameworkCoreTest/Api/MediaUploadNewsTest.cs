using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Api;
using WX.Model.ApiResponses;
using WX.Model.ApiRequests;
using WX.Model;
using Xunit;
namespace FrameworkCoreTest
{
    public class MediaUploadNewsTest : MockPostApiBaseTest<MediaUploadNewsRequest, MediaUploadNewsResponse>
    {
        [Fact]
        public void MediaUploadNewsPostContentTest()
        {
            Console.WriteLine(Request.GetPostContent());
        }

        [Fact]
        public void MockMediaUploadNewsTest()
        {
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal("news", response.Type);
            Assert.Equal(1391857799, response.CreatedAt);
        }

        [Fact]
        public void MockMediaUploadNewsErrorTest()
        {
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
            Console.WriteLine(response);
        }

        protected override MediaUploadNewsRequest InitRequestObject()
        {
            return new MediaUploadNewsRequest
            {
                AccessToken = "123",
                Articles = new List<ArticleMessage>()
                {
                    new ArticleMessage{
                        ThumbMediaId = "image1",
                        Author = "jamesying",
                        Title = "test news 1",
                        Url= "newsurl1",
                        Content = "content1",
                        Description = "discription1"
                    },
                    new ArticleMessage{
                        ThumbMediaId = "image2",
                        Author = "jamesying",
                        Title = "test news 2",
                        Url= "newsurl2",
                        Content = "content2",
                        Description = "discription2"
                    }
                }
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return "{\"errcode\":40018,\"errmsg\":\"invalid button name size\"}";
            return @"{
               ""type"":""news"",
               ""media_id"":""CsEf3ldqkAYJAU6EJeIkStVDSvffUJ54vqbThMgplD-VJXXof6ctX5fI6-aYyUiQ"",
               ""created_at"":1391857799
            }";
        }
    }
}
