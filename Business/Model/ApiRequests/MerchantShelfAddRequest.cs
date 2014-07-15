using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;

namespace WX.Model.ApiRequests
{
    public class MerchantShelfAddRequest : ApiRequest<MerchantShelfAddResponse>
    {
        public MerchantShelfAddRequest()
        {
            Modules = new List<ShelfModule>();
        }

        [JsonProperty("shelf_banner", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ShelfBanner
        {
            get
            {
                if (m_needbanner)
                {
                    return m_shelfbanner;
                }
                return null;
            }
            set
            {
                m_shelfbanner = value;
            }
        }


        private string m_shelfbanner = String.Empty;
        private bool m_needbanner = true;
        [JsonProperty("shelf_name", Required = Required.Always)]
        public string ShelfName { get; set; }

        [JsonIgnore]
        private ICollection<ShelfModule> Modules { get; set; }

        [JsonProperty("shelf_data")]
        internal ShelfModulesInfo ShelfData { get; set; }

        public void AddModules(ShelfModuleOne one, 
            ShelfModuleTwo two, 
            ShelfModuleThree three, 
            ShelfModuleFour four)
        {
            Modules.Clear();
            if (one != null) Modules.Add(one);
            if (two != null) Modules.Add(two);
            if (three != null) Modules.Add(three);
            if (four != null) Modules.Add(four);
            ShelfData = new ShelfModulesInfo(Modules);
        }

        public void AddModules(ShelfModuleFive five)
        {
            Modules.Clear();
            if (five != null)
                Modules.Add(five);

            ShelfData = new ShelfModulesInfo(Modules);
            m_needbanner = false;
            ShelfBanner = String.Empty;
        }

        internal override string Method
        {
            get { return POSTMETHOD; }
        }

        protected override string UrlFormat
        {
            get { return "https://api.weixin.qq.com/merchant/shelf/add?access_token={0}"; }
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
            if (Modules == null || !Modules.Any())
            {
                throw new ArgumentNullException("must add shelfmodule, use addModule function");
            }
        }
    }
}
