using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取接口分析数据（getinterfacesummary）	
    /// </summary>
    public class DatacubeGetInterfaceSummaryRequest : DatacubeGetInterfaceRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getinterfacesummary?access_token={0}"; }
        }
    }
}
