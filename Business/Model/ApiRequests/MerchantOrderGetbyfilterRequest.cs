using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class MerchantOrderGetbyfilterRequest : ApiRequest<MerchantOrderGetbyfilterResponse>
    {
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public OrderStatus Status { get; set; }

        [JsonIgnore]
        public DateTime BeginTime { get; set; }

        [JsonIgnore]
        public DateTime EndTime { get; set; }

        [JsonProperty("begintime")]
        internal long JsonBeginTime
        {
            get
            {
                return BeginTime.ConvertToTimeStamp();
            }
        }

        [JsonProperty("endtime")]
        internal long JsonEndTime
        {
            get
            {
                return EndTime.ConvertToTimeStamp();
            }
        }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/order/getbyfilter?access_token={0}"; }
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
