using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WX.Common;
using WX.Logger;
using WX.Pay.Request;
using WX.Pay.Response;

namespace WX.Pay
{
    public class PayApiClient : IPayApiClient
    {
        public ILogger Logger { get; set; }

        public T Execute<T>(PayRequest<T> request) where T : PayResponse, new()
        {
            
            T result = null;
            try
            {
                var responseXml = HttpHelper.HttpPost(request.Url, request.Serializable());
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(responseXml));
                var xs = new XmlSerializer(typeof(T), "");
                result =  (T)xs.Deserialize(stream);
            }
            catch(Exception e)
            {
                Error(e.ToString());
            }

            if (result == null)
            {
                return new T()
                {
                    
                };
            }

            return result;
        }

        public void Error(string content)
        {
            if (Logger != null)
            {
                Logger.Error(content);
            }
        }
    }
}
