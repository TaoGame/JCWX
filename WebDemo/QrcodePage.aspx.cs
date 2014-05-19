using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WX.OAuth;
using System.Configuration;
using WX.Model;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace WebDemo
{
    public partial class QrcodePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var api = Request["Api"];
            if (String.IsNullOrEmpty(api))
                return;

            var manager = new OAuthHelper(ConfigurationManager.AppSettings["wxappid"]);
            var url = manager.BuildOAuthUrl("http://wx.taogame.com/OAuthUserInfoDemo.aspx",
                api == "snsapi_base" ? OAuthScope.Base : OAuthScope.UserInfo,
                api);


            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(url, out qrCode);

        
            GraphicsRenderer gRenderer = new GraphicsRenderer(
                new FixedModuleSize(2, QuietZoneModules.Two),
                Brushes.Black, Brushes.White);

            MemoryStream ms = new MemoryStream();
            gRenderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);

            Response.BinaryWrite(ms.ToArray());
        }
    }
}