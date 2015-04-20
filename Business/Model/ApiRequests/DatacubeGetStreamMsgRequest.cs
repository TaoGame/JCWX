using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public abstract class DatacubeGetStreamMsgRequest : ApiRequest<DatacubeGetStreamMsgResponse>
    {
        [JsonProperty("begin_date")]
        public string BeginDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected abstract override string UrlFormat { get; }

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
