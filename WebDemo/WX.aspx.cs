using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using WX.Demo.WebClasses;
using WX.Model;

namespace WebDemo
{
    public partial class WX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //微信服务器一直把用户发过来的消息，post过来
                if (Request.HttpMethod == "POST")
                {
                    var reader = XmlReader.Create(Request.InputStream);
                    
                    var doc = XDocument.Load(reader);
                    MyLog.Log(doc.ToString());
                    var xml = doc.Element("xml");
                    var msg = new MiddleMessage(xml);
                    //把inputstream转换成xelement后，直接交给WebMessageRole来处理吧
                    var responseMessage =  new WebMessageRole()
                        .MessageRole(msg)
                        .HandlerRequestMessage(msg);

                    if (responseMessage != null)
                    {
                        Response.Write(responseMessage.Serializable());
#if DEBUG
                        MyLog.Log(responseMessage.Serializable());
#endif
                    }
                }
                else if (Request.HttpMethod == "GET") //微信服务器在首次验证时，需要进行一些验证，但。。。。
                {
                    //我仅需返回给他echostr中的值，就为验证成功，可能微信觉得这些安全策略是为了保障我的服务器，要不要随你吧
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