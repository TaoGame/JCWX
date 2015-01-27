using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX
{
    public class CustomAccount
    {
        [JsonProperty("kf_account", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 完整客服账号，格式为：账号前缀@公众号微信号
        /// </summary>
        public string Account { get; set; }

        [JsonProperty("kf_nick", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服昵称
        /// </summary>
        public string Nick { get; set; }

        [JsonProperty("kf_id", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服工号
        /// </summary>
        public string ID { get; set; }

        [JsonProperty("kf_headimg", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImg { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服在线状态 1：pc在线，2：手机在线。若pc和手机同时在线则为 1+2=3
        /// </summary>
        public int Status { get; set; }

        [JsonProperty("auto_accept", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服设置的最大自动接入数
        /// </summary>
        public int AutoAccept { get; set; }

        [JsonProperty("accepted_case", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服当前正在接待的会话数
        /// </summary>
        public int AcceptedCase { get; set; }

        [JsonProperty("nickname", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服昵称，最长6个汉字或12个英文字符
        /// </summary>
        public string NickName { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        /// <summary>
        /// 客服账号登录密码，格式为密码明文的32位加密MD5值
        /// </summary>
        public string Password { get; set; }
    }
}
