using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    /// <summary>
    /// 添加运费模板
    /// </summary>
    public class MerchantExpressAddResponse : ApiResponse
    {
        [JsonProperty("template_id")]
        public int TemplateID { get; set; }
    }
}
