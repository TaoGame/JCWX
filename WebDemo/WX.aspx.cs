using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using WebDemo.App_Code;

namespace WebDemo
{
    public partial class WX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.HttpMethod == "POST")
                {
                    var reader = XmlReader.Create(Request.InputStream);
                    
                    var doc = XDocument.Load(reader);
                    MyLog.Log(doc.ToString());
                    var xml = doc.Element("xml");
                    var responseMessage =  new WebMessageRole()
                        .MessageRole(xml)
                        .HandlerRequestMessage(xml);

                    if (responseMessage != null)
                    {
                        Response.Write(responseMessage.Serializable());
#if DEBUG
                        MyLog.Log(responseMessage.Serializable());
#endif
                    }
                }
                else
                {
                    MyLog.Log("get info:" + Request["echostr"].ToString());
                    Response.Write(Request["echostr"].ToString());
                }
            }
            catch (Exception ex)
            {
                MyLog.Log("error:" + ex.ToString());
            }
        }
    }
}