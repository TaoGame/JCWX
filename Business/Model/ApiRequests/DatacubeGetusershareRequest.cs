using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    public class DatacubeGetusershareRequest : DatacubeGetarticlesummaryRequest
    {
        protected override string UrlFormat
        {
            get
            {
                return "https://api.weixin.qq.com/datacube/getusershare?access_token={0}";
            }
        }
    }
}
