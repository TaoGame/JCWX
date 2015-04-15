using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class GetCurrentAutoreplyInfoResponse : ApiResponse
    {
        /// <summary>
        /// 关注后自动回复是否开启，0代表未开启，1代表开启
        /// </summary>
        [JsonProperty("is_add_friend_reply_open")]
        public int IsAddFriendReplyOpen { get; set; }

        /// <summary>
        /// 消息自动回复是否开启，0代表未开启，1代表开启
        /// </summary>
        [JsonProperty("is_autoreply_open")]
        public int IsAutoreplyOpen { get; set; }

        /// <summary>
        /// 关注后自动回复的信息
        /// </summary>
        [JsonProperty("add_friend_autoreply_info")]
        public AutoReplyInfo AddFriendAutoreplyInfo { get; set; }

        /// <summary>
        /// 消息自动回复的信息
        /// </summary>
        [JsonProperty("message_default_autoreply_info")]
        public AutoReplyInfo MessageDefaultAutoreplyInfo { get; set; }

        /// <summary>
        /// 关键词自动回复的信息
        /// </summary>
        [JsonProperty("keyword_autoreply_info")]
        public KeywordAutoreplyInfo KeywordAutoreplyInfo { get; set; }
    }
}
