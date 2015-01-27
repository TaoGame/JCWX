using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 设置行业可在MP中完成，每月可修改行业1次，账号仅可使用所属行业中相关的模板，为方便第三方开发者，提供通过接口调用的方式来修改账号所属行业，具体如下：
    /// </summary>
    public class TemplateApisetindustryRequest : ApiRequest<DefaultResponse>
    {
        /// <summary>
        /// 主行业
        /// </summary>
        [JsonIgnore]
        public TemplateIndustry Industry_id1 { get; set; }

        /// <summary>
        /// 副行业
        /// </summary>
         [JsonIgnore]
        public TemplateIndustry Industry_id2 { get; set; }

        [JsonProperty("industry_id1")]
        protected string Id1
        {
            get
            {
                return ((int)Industry_id1).ToString();
            }
        }
        [JsonProperty("industry_id2")]
        protected string Id2
        {
            get
            {
                return ((int)Industry_id2).ToString();
            }
        }
        
        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={0}"; }
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
