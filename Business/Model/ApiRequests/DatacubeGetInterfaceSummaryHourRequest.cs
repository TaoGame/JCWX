using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取接口分析分时数据（getinterfacesummaryhour）	
    /// </summary>
    public class DatacubeGetInterfaceSummaryHourRequest : DatacubeGetInterfaceRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getinterfacesummaryhour?access_token={0}"; }
        }
    }
}
