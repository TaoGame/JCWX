using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class TemplateDataProperty
    {
        public TemplateDataProperty() { }

        public TemplateDataProperty(string value, string color)
        {
            Value = value;
            Color = color;
        }

        /// <summary>
        /// 显示的文本
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// 显示的颜色
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
