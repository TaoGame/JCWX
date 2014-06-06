using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class CustomServiceGetRecordResponse : ApiResponse
    {
        [JsonProperty("recordlist")]
        public IEnumerable<CustomServiceRecord> RecordList;
    }
}
