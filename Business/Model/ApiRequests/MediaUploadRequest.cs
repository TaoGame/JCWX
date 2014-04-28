using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class MediaUploadRequest : ApiRequest<MediaUploadResponse>
    {
        public string FilePath { get; set; }

        public MediaType MediaType { get; set; }

        internal override string Method
        {
            get { return "FILE"; }
        }

        protected override string UrlFormat
        {
            get { return "http://file.api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, MediaType);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return FilePath;
        }

        internal override void Validate()
        {
            base.Validate();
            FileInfo file = new FileInfo(FilePath);
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }

            if (file.Extension != ".jpg" &&
                file.Extension != ".amr" &&
                file.Extension != ".mp3" &&
                file.Extension != ".mp4")
            {
                throw new NotSupportedException("不支持上传的文件类型");
            }
        }
    }
}
