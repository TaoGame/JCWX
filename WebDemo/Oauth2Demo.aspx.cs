using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.Model.ApiResponses;

namespace WebDemo
{
    public partial class Oauth2Demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WeiXinUser = new UserInfoResponse
            {
                Nickname = "jaemsying"
            };
            Code = Request["Code"];
        }

        public UserInfoResponse WeiXinUser { get; set; }

        public string Code { get; set; }
    }
}