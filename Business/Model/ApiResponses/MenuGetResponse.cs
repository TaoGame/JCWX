using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class MenuGetResponse : ApiResponse
    {
        public Menu Menu { get; set; }
    }

    public class Menu
    {
        [JsonProperty("button")]
        public IEnumerable<ClickButton> Buttons { get; set; }
    }
}
