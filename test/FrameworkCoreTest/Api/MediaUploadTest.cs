using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WX.Common;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;
using Xunit;

namespace FrameworkCoreTest
{
    public class MediaUploadTest : MockPostApiBaseTest<MediaUploadRequest, MediaUploadResponse>
    {
        
        [Fact]
        public void MediaUploadReallyTest()
        {
            var response = m_client.Execute(Request);
            if (response.IsError)
                Console.WriteLine(response.ToString());
            Console.WriteLine(response.MediaId);
        }

        [Fact]
        public void MockMediaUploadTest()
        {
            IsMock = true;
            MockSetup(false);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal("MEDIA_ID", response.MediaId);
        }

        [Fact]
        public void MockMediaUploadErrorTest()
        {
            IsMock = true;
            MockSetup(true);
            var response = mock_client.Object.Execute(Request);
            Assert.Equal(true, response.IsError);
        }



        protected override MediaUploadRequest InitRequestObject()
        {
            return new MediaUploadRequest
            {
                AccessToken = GetCurrentToken(),
                FilePath = @"C:\Users\JamesYing\Desktop\123.amr",
                MediaType = MediaType.Voice
            };
        }

        protected override string GetReturnResult(bool errResult)
        {
            if (errResult)
                return s_errmsg;
            return "{\"type\":\"Image\",\"media_id\":\"MEDIA_ID\",\"created_at\":123456789}";
        }
    }
}
