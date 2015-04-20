using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class CustomserviceKfsessionGetwaitcaseResponse : ApiResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("waitcaselist")]
        public IEnumerable<WaitCase> WaitCaseList { get; set; }
    }
}
