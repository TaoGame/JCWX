using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public enum ActionName
    {
        NONE,
        QR_SCENE,
        QR_LIMIT_SCENE
    }

    public class ActionInfo
    {
        public Scene Scene { get; set; }
    }

    public class Scene
    {
        [JsonProperty("scene_id")]
        public int SceneId { get; set; }
    }

    public class QrcodeCreateRequest : ApiRequest<QrcodeCreateResponse>
    {
        [JsonProperty("expire_seconds", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int ExpireSeconds { get; set; }

        [JsonProperty("action_name", DefaultValueHandling= DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActionName ActionName { get; set; }

        [JsonProperty("action_info")]
        public ActionInfo ActionInfo { get; set; }

        internal override string Method
        {
            get { return "POST"; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        public override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal override void Validate()
        {
            base.Validate();
            if (this.ActionName == ApiRequests.ActionName.QR_SCENE)
            {
                if (this.ExpireSeconds <= 0 || this.ExpireSeconds > 1800)
                {
                    throw new ArgumentException("临时二维码过期时间必须大于0小于1800秒");
                }
            }

            if (this.ActionName == ApiRequests.ActionName.QR_LIMIT_SCENE)
            {
                this.ExpireSeconds = 0;
            }
        }
    }
}
