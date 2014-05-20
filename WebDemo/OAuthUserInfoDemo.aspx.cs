using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Api;
using WX.Model;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;

namespace WebDemo
{
    public partial class OAuthUserInfoDemo : System.Web.UI.Page
    {
        private IApiClient m_client = new DefaultApiClient();
        private AppIdentication m_appIdent = new AppIdentication(
            ConfigurationManager.AppSettings["wxappid"],
            ConfigurationManager.AppSettings["wxappsecret"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["Code"] == null)
            {
                throw new ArgumentNullException("Code is null");
            }

            Label1.Text = Request["Code"];
            Label6.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var request = new SnsOAuthAccessTokenRequest
            {
                AppID = m_appIdent.AppID,
                AppSecret = m_appIdent.AppSecret,
                Code = Label1.Text
            };
            var response = m_client.Execute(request);
            if (!response.IsError)
            {
                Label2.Text = response.AccessToken;
                Label3.Text = response.RefreshToken;
                Label5.Text = response.OpenId;
            }
            else
            {
                Label6.Text = response.ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var request = new SnsOauthRefreshTokenRequest
            {
                AppID = m_appIdent.AppID,
                RefreshToken = Label3.Text
            };
            var response = m_client.Execute(request);
            if (!response.IsError)
            {
                Label2.Text = response.AccessToken;
                Label3.Text = response.RefreshToken;
                Label5.Text = response.OpenId;
            }
            else
            {
                Label6.Text = response.ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SnsUserInfoRequest request = new SnsUserInfoRequest
            {
                OAuthToken = Label2.Text,
                Lang = Language.CN,
                OpenId = Label5.Text
            };
            SnsUserInfoResponse response = m_client.Execute(request);
            if (response.IsError)
            {
                Label6.Text = response.ToString();
            }
            else
            {
                Label4.Text = response.NickName;
            }
        }
    }
}