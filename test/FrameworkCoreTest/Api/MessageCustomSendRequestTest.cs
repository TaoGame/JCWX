using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using WX.Api;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;

namespace FrameworkCoreTest
{
    public class MessageCustomSendRequestTest : MockPostApiBaseTest<MessageCustomSendRequest, MessageCustomSendResponse>
    {
        [Fact]
        public void SendRequestTest()
        {
            var textRequest = new MessageCustomSendTextRequest
            {
                AccessToken = "123",
                ToUser = "james",
                Text = new TextMessage
                {
                    Content = "test content"
                }
            };

            var imageRequest = new MessageCustomSendImageRequest
            {
                ToUser = "james",
                Image = new ImageMessage
                {
                    MediaId = "image_media_id"
                }
            };

            var voiceRequest = new MessageCustomSendVoiceRequest
            {
                ToUser = "james",
                Voice = new VoiceMessage
                {
                    MediaId = "voice_media_id"
                }
            };

            var videoRequest = new MessageCustomSendVideoRequest
            {
                ToUser = "james",
                Video = new VideoMessage
                {
                    MediaId = "video_media_id",
                    Title = "video test title"
                }
            };

            var musicRequest = new MessageCustomSendMusicRequest
            {
                ToUser = "james",
                Music = new MusicMessage
                {
                    Title = "test music title",
                    HQMusicUrl = "hqmusicurl",
                    MusicUrl = "musicurl",
                    ThumbMediaId = "media_id"
                }
            };

            var newsRequest = new MessageCustomSendNewsRequest
            {
                ToUser = "james",
                News = new NewsMessage
                {
                    Articles = new List<NewsArticleMessage>
                    {
                        new NewsArticleMessage{
                            Title = "Happy Day",
                            Description = "Is Really A Happy Day",
                            Url = "url1",
                            PicUrl = "picurl1"
                        },
                        new NewsArticleMessage {
                            Title = "Happy Day",
                            Description = "Is Really A Happy Day",
                            Url = "url2",
                            PicUrl = "picurl2"
                        }
                    }
                }
            };

            Console.WriteLine(textRequest.GetPostContent());
            Console.WriteLine(imageRequest.GetPostContent());
            Console.WriteLine(voiceRequest.GetPostContent());
            Console.WriteLine(videoRequest.GetPostContent());
            Console.WriteLine(musicRequest.GetPostContent());
            Console.WriteLine(newsRequest.GetPostContent());
        }

        [Fact]
        public void ReallyMessageCustomSendTextTest()
        {
            var request = new MessageCustomSendTextRequest
            {
                AccessToken = GetCurrentToken(),
                ToUser = "oI1_vjirqEuoDttmL-eRcsO-G9to",
                Text = new TextMessage
                {
                    Content = "hello james1<a href='http://www.cnblogs.com'>123</a>"
                }
            };

            var response = m_client.Execute(request);
            if (response.IsError)
            {
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("send is ok");
            }
        }

        [Fact]
        public void ReallyMessageCustomSendNewsTest()
        {
            var request = new MessageCustomSendNewsRequest
            {
                AccessToken = GetCurrentToken(),
                ToUser = "oI1_vjirqEuoDttmL-eRcsO-G9to",
                News = new NewsMessage
                {
                    Articles = new List<NewsArticleMessage>
                    {
                        new NewsArticleMessage{
                            Title = "博客园",
                            Description = "博客园，技术改变人生",
                            Url = "http://inday.cnblogs.com",
                            PicUrl = "http://static.cnblogs.com/images/logo_small.gif"
                        },
                        new NewsArticleMessage{
                             Title = "博客园",
                            Description = "博客园，技术改变人生",
                            Url = "http://inday.cnblogs.com",
                            PicUrl = "http://static.cnblogs.com/images/logo_small.gif"
                        }
                    }
                }
            };

            var response = m_client.Execute(request);
            if (response.IsError)
            {
                Console.WriteLine(response);
            }
            else
            {
                Console.WriteLine("send is ok");
            }
        }

        protected override MessageCustomSendRequest InitRequestObject()
        {
            throw new NotImplementedException();
        }

        protected override string GetReturnResult(bool errResult)
        {
            throw new NotImplementedException();
        }
    }
}
