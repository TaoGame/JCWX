using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取消息分送分时数据（getupstreammsghour）	
    /// </summary>
    public class DatacubeGetUpStreamMsgHourRequest : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getupstreammsghour?access_token={0}"; }
        }
    }
}
