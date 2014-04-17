using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;
using WX.Model.Exceptions;

namespace WX.Model.ApiRequests
{
    public class MenuCreateRequest : ApiRequest<MenuCreateResponse>
    {
        [JsonProperty("button")]
        public IEnumerable<ClickButton> Buttons { get; set; }

        internal override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal override void Validate()
        {
            base.Validate();

            if (Buttons == null)
            {
                throw new ArgumentNullException("button is null");
            }
        }
    }
}
