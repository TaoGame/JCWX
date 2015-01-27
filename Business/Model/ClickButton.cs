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
        view,
        scancode_waitmsg,   //扫码推事件
        scancode_push,  //扫码推事件且弹出“消息接收中”提示框
        pic_sysphoto,   //弹出系统拍照发图
        pic_photo_or_album, //弹出拍照或者相册发图
        pic_weixin, //  弹出微信相册发图器
        location_select     //弹出地理位置选择器
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
