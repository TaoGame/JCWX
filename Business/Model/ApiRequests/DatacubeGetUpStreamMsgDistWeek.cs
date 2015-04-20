using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取消息发送分布周数据（getupstreammsgdistweek）	
    /// </summary>
    public class DatacubeGetUpStreamMsgDistWeek : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getupstreammsgdist?access_token={0}"; }
        }
    }
}
