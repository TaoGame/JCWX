using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class GetCurrentSelfmenuInfoResponse : ApiResponse
    {
        /// <summary>
        /// 菜单是否开启，0代表未开启，1代表开启
        /// </summary>
        [JsonProperty("is_menu_open")]
        public int IsMenuOpen { get; set; }

        /// <summary>
        /// 菜单信息
        /// </summary>
        [JsonProperty("selfmenu_info")]
        public SelfMenuInfo SelfMenuInfo { get; set; } 
    }
}
