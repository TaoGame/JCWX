using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class DatacubeGetUserCumulateRequest : ApiRequest<DatacubeGetUserCumulateResponse>
    {
        /// <summary>
        /// 开始时间，字符串，格式：yyyy-MM-dd
        /// </summary>
        [JsonProperty("begin_date")]
        public string BeginDate { get; set; }

        /// <summary>
        /// 结束时间，字符串，格式：yyyy-MM-dd
        /// </summary>
        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getusercumulate?access_token={0}"; }
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
