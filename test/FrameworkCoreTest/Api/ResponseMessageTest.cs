using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Model;
using Xunit;

namespace FrameworkCoreTest
{
    public class ResponseMessageTest
    {
        [Fact]
        public void ResponseImageMessageTest()
        {
            var response = new ResponseImageMessage
            {
                FromUserName = "james",
                ToUserName = "ying",
                CreateTime = 123123,
                Image = new ImageMessage
                {
                    MediaId = "123"
                }
            };

            Console.WriteLine(response.Serializable());
        }

        [Fact]
        public void ResponseVoiceMessageTest()
        {
            var response = new ResponseVoiceMessage
            {
                FromUserName = "jamesying",
                ToUserName = "ying",
                CreateTime = 123123,
                Voice = new VoiceMessage
                {
                    MediaId = "123123"
                }
            };

            Console.WriteLine(response.Serializable());
        }

        [Fact]
        public void ResponseVideoMessageTest()
        {
            var response = new ResponseVideoMessage
            {
                FromUserName = "jamesying",
                ToUserName = "ying",
                CreateTime = 123123,
                Video = new VideoMessage
                {
                    MediaId = "123123",
                    Description = "123123",
                    Title = "123123"
                }
            };

            Console.WriteLine(response.Serializable());
        }

        [Fact]
        public void ResponseMusicMessageTest()
        {
            var response = new ResponseMusicMessage
            {
                FromUserName = "jamesying",
                ToUserName = "ying",
                CreateTime = 123123,
                Music = new MusicMessage
                {
                    MusicUrl = "asdfasdf",
                    HQMusicUrl = "asdfasdf",
                    ThumbMediaId = "asdfasdf",
                    Description = "123123",
                    Title = "123123"
                }
            };

            Console.WriteLine(response.Serializable());
        }

        [Fact]
        public void ResponseNewsMessageTest()
        {
            var response = new ResponseNewsMessage
            {
                FromUserName = "jamesying",
                ToUserName = "ying",
                ArticleCount = 1,
                Articles = new List<ArticleMessage>
                {
                    new ArticleMessage{
                        Author = "james",
                        Url = "http://www.test.com",
                        ThumbMediaId = "http://123123123.com",
                        Content = "test content",
                        PicUrl = "aljslkdjflkasdf",
                        Description = "askdlfkjasdf",
                        Title = "test title"
                    },
                }
            };

            Console.WriteLine(response.Serializable());
        }
    }
}
