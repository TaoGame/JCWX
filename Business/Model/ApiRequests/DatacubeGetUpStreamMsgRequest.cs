using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    /// <summary>
    /// 获取消息发送概况数据（getupstreammsg）
    /// </summary>
    public class DatacubeGetUpStreamMsgRequest : DatacubeGetStreamMsgRequest
    {
        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/datacube/getupstreammsg?access_token={0}"; }
        }
    }
}
