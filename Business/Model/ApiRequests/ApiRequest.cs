using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiResponses;
using WX.Model.Exceptions;

namespace WX.Model.ApiRequests
{
    public abstract class ApiRequest<T>
        where T : ApiResponse
    {
        internal abstract string Method { get; }

        protected abstract string UrlFormat { get; }

        internal abstract string GetUrl();

        protected abstract bool NeedToken { get; }

        internal virtual bool NotHasResponse
        {
            get
            {
                return false;
            }
        }

        internal virtual void Validate()
        {
            if (NeedToken && String.IsNullOrEmpty(AccessToken))
            {
                throw new WXApiException(-99, "AccessToken 为空或已过期");
            }
        }

        [JsonIgnore]
        public string AccessToken { get; set; }

        public abstract string GetPostContent();
    }
}
