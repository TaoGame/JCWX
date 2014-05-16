using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Api;
using WX.Model;
using System.Configuration;
using WX.Model.Exceptions;
using WX.Model.ApiRequests;

namespace WX.Framework
{
    public sealed class ApiAccessTokenManager
    {
        private ApiAccessTokenManager()
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(s_configAppId) &&
                ConfigurationManager.AppSettings.AllKeys.Contains(s_configAppSecret))
            {
                m_appIdentity = new AppIdentication(
                    ConfigurationManager.AppSettings[s_configAppId],
                    ConfigurationManager.AppSettings[s_configAppSecret]);
            }
        }

        private static ApiAccessTokenManager m_instance;
        private static object m_lock = new object();
        private static string s_configAppId = "wxappid";
        private static string s_configAppSecret = "wxappsecret";
        public static ApiAccessTokenManager Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_lock)
                    {
                        if (m_instance == null)
                        {
                            m_instance = new ApiAccessTokenManager();
                        }
                    }
                }

                return m_instance;
            }
        }

        public string GetCurrentToken()
        {
            if (String.IsNullOrEmpty(Token) ||
                DateTime.Now >= ExpireTime)
            {
                RefeshToken();
            }

            return Token;
        }

        private void RefeshToken()
        {
            if (m_appIdentity == null)
            {
                throw new WXApiException(-100, "请先设置好AppID与AppSecret");
            }

            //Console.WriteLine("refesh token");
            var now = DateTime.Now;
            var request = new AccessTokenRequest(m_appIdentity);
            var response = Client.Execute(request);
            if (response.IsError)
            {
                throw new WXApiException(response.ErrorCode, response.ErrorMessage);
            }

            ExpireTime = now.AddSeconds(response.Expires_In);
            Token = response.Access_Token;
        }

        private IApiClient m_client;
        public IApiClient Client
        {
            get
            {
                if (m_client == null)
                {
                    m_client = new DefaultApiClient();
                }

                return m_client;
            }
        }

        private AppIdentication m_appIdentity;

        public string Token { get; private set; }

        public DateTime ExpireTime { get; private set; }

        public void SetAppIdentity(string appId, string appSecret)
        {
            SetAppIdentity(new AppIdentication(appId, appSecret));
        }

        public void SetAppIdentity(AppIdentication appIdentity)
        {
            m_appIdentity = appIdentity;
        }
    }
}
