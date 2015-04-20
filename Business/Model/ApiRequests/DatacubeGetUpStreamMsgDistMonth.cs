using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取消息发送分布月数据（getupstreammsgdistmonth）	
    /// </summary>
    public class DatacubeGetUpStreamMsgDistMonth : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getupstreammsgdistmonth?access_token={0}"; }
        }
    }
}
