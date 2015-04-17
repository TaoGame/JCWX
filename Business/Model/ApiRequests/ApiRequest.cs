using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Logger;
using WX.Model.ApiResponses;
using WX.Model.Exceptions;

namespace WX.Model.ApiRequests
{
    public abstract class ApiRequest<T>
        where T : ApiResponse
    {   
        protected const string POSTMETHOD = "POST";
        protected const string GETMETHOD = "GET";
        protected const string FILEMETHOD = "FILE";

        internal abstract string Method { get; }

        protected abstract string UrlFormat { get; }

        [JsonIgnore]
        public ILogger Logger { get; set; }

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
            Log(GetUrl());
            if (NeedToken && String.IsNullOrEmpty(AccessToken))
            {
                Log(new WXApiException(-99, "AccessToken 为空或已过期"));
            }
        }

        public void Log(Exception ex)
        {
            if (Logger == null)
            {
                throw ex;
            }
            else
            {
                Logger.Log(ex.ToString());
            }
        }

        public void Log(string content)
        {
            if (Logger != null)
            {
                Logger.Log(content);
            }
        }

        [JsonIgnore]
        public string AccessToken { get; set; }

        public abstract string GetPostContent();
    }
}
