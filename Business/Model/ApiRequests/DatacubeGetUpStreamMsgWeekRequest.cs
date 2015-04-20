using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取消息发送周数据（getupstreammsgweek）	
    /// </summary>
    public class DatacubeGetUpStreamMsgWeekRequest : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getupstreammsgweek?access_token={0}"; }
        }
    }
}
