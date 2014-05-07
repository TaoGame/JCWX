using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Api;
using WX.Framework;
using WX.Model;

namespace FrameworkCoreTest
{
    public abstract class BaseTest
    {
        private static string tokenfile = "token.txt";

        static BaseTest()
        {
            //ApiAccessTokenManager.Instance.SetAppIdentity(m_appIdentity);
        }

        

        protected IApiClient m_client = new DefaultApiClient();

        protected Mock<DefaultApiClient> mock_client = new Mock<DefaultApiClient>();

        public virtual string GetCurrentToken()
        {
            if (File.Exists(tokenfile))
            {
                var strs = File.ReadAllText(tokenfile, Encoding.UTF8);
                var splitstrs = strs.Split(new char[] { '|' });
                var token = splitstrs[0];
                var expirtime = DateTime.Parse(splitstrs[1]);
                if (expirtime <= DateTime.Now)
                {
                    return GetToken();
                }

                return token;
            }
            else
            {
                return GetToken();
            }
            
        }

        private string GetToken()
        {
            var token = GetCurrentToken();
            var expirtime = ApiAccessTokenManager.Instance.ExpireTime;
            File.WriteAllText(tokenfile, token + "|" + expirtime.ToString(), Encoding.UTF8);

            return token;
        }
    }
}
