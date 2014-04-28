using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class MediaGetRequest : ApiRequest<MediaGetResponse>
    {
        public string MediaId { get; set; }

        internal override string Method
        {
            get { return "GET"; }
        }

        protected override string UrlFormat
        {
            get { return "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken, MediaId);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            throw new NotImplementedException();
        }

        internal override bool NotHasResponse
        {
            get
            {
                return true;
            }
        }

        internal override void Validate()
        {
            base.Validate();
            if (String.IsNullOrEmpty(MediaId))
            {
                throw new ArgumentNullException("MediaId is null");
            }
        }
    }
}
