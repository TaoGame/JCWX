using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public enum ConvertType
    {
        Long2Short = 0,
        Short2Long = 1
    }

    public class ShorturlRequest : ApiRequest<ShorturlResponse>
    {
        /// <summary>
        /// 此处填long2short，代表长链接转短链接
        /// </summary>
        [JsonIgnore]
        public ConvertType Action { get; set; }

        /// <summary>
        /// 需要转换的长链接，支持http://、https://、weixin://wxpay 格式的url
        /// </summary>
        [JsonProperty("long_url")]
        public string Url { get; set; }

        [JsonProperty("action")]
        protected string CAction
        {
            get
            {
                return Action.ToString().ToLower();
            }
        }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}"; }
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
    }
}
