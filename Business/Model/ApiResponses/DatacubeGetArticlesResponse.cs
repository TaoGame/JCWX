using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    /// <summary>
    /// 所有获取图文统计的Request均得到此Response
    /// 1、获取图文群发每日数据 getarticlesummary
    /// 2、获取图文群发总数据（getarticletotal）
    /// 3、获取图文统计数据（getuserread）
    /// 4、获取图文统计分时数据（getuserreadhour）
    /// 5、获取图文分享转发数据（getusershare）
    /// 6、获取图文分享转发分时数据（getusersharehour）
    /// </summary>
    public class DatacubeGetArticlesResponse : ApiResponse
    {
        /// <summary>
        /// 返回的图文统计数据列表
        /// </summary>
        [JsonProperty("list")]
        public IEnumerable<DatacubeArticle> Stats { get; set; }
    }
}
