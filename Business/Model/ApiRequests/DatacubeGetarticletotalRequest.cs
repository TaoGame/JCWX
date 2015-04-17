using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取图文群发总数据（getarticletotal）	
    /// </summary>
    public class DatacubeGetarticletotalRequest : DatacubeGetarticlesummaryRequest
    {
        protected override string UrlFormat
        {
            get
            {
                return "https://api.weixin.qq.com/datacube/getarticletotal?access_token={0}";
            }
        }
    }
}
