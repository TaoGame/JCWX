using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Model;
using WX.Model.ApiResponses;
using WX.OAuth;

namespace WebDemo
{
    public partial class Oauth2Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "0")
            {
                Image1.ImageUrl = "~/Qrcodepage.aspx?api=" + DropDownList1.SelectedValue;
                Image1.Visible = true;
                var manager = new OAuthHelper(ConfigurationManager.AppSettings["wxappid"]);
                var url = manager.BuildOAuthUrl("http://wx.taogame.com/OAuthUserInfoDemo.aspx",
                    DropDownList1.SelectedValue == "snsapi_base" ? OAuthScope.Base : OAuthScope.UserInfo,
                    DropDownList1.SelectedValue);
                Label1.Text = url;
            }
            else
            {
                Image1.Visible = false;
                Label1.Visible = true;
            }
        }

       
    }
}