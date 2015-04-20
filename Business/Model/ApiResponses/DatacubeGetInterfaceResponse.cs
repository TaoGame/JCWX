using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class DatacubeGetInterfaceResponse : ApiResponse
    {
        [JsonProperty("list")]
        public IEnumerable<DatacubeInterface> List { get; set; }
    }
}
