using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public enum ClickButtonType
    {
        None,
        click,
        view
    }

    public class ClickButton
    {
        [JsonProperty("type",
            DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClickButtonType Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key",
            NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("url",
            NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("sub_button",
            NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<ClickButton> SubButton { get; set; }
    }
}
