using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class CustomserviceKfaccountUpdateRequest : ApiRequest<DefaultResponse>
    {
        /// <summary>
        /// 完整客服账号，格式为：账号前缀@公众号微信号，账号前缀最多10个字符，必须是英文或者数字字符。如果没有公众号微信号，请前往微信公众平台设置。
        /// </summary>
        [JsonProperty("kf_account")]
        public string Account { get; set; }

        /// <summary>
        /// 客服昵称，最长6个汉字或12个英文字符
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        /// <summary>
        /// 客服账号登录密码，格式为密码明文的32位加密MD5值
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}"; }
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
