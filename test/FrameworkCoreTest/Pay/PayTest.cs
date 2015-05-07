using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WX.Pay;
using WX.Pay.Request;
using WX.Pay.Response;
using Xunit;
using System.Configuration;

namespace FrameworkCoreTest.Pay
{
    public abstract class PayTest<T, K>
        where T : PayRequest<K>
        where K : PayResponse, new ()
    {
        [Fact]
        public void MockTest()
        {
            T request = GetRequest();
            Console.WriteLine("step start......");
            Console.WriteLine("api url:{0}", request.Url);
            Console.WriteLine("api data:{0}", request.Serializable());
            Console.WriteLine("------------------");
            var xml = GetResponseXml();
            Console.WriteLine("api response:{0}", xml);
            K k = ParseResponse(xml);
            Console.WriteLine(k.AppId);
            Console.WriteLine(k.DeviceInfo);
            Assert.IsType<K>(k);
            var pro = k.GetType().GetProperties();
            foreach (var p in pro)
            {
                Console.WriteLine("{0}:{1}", p.Name, JsonConvert.SerializeObject(p.GetValue(k)));
            }
        }

        [Fact]
        public void ReallyTest()
        {
            var client = new PayApiClient();
            T request = GetRequest();
            request.AppId = ConfigurationManager.AppSettings["wxappid"];
            request.MchId = ConfigurationManager.AppSettings["mchid"];
            request.PayApiSecret = ConfigurationManager.AppSettings["paysecret"];


            client.Logger = new Logger();
            Console.WriteLine("step start......");
            Console.WriteLine("api url:{0}", request.Url);
            Console.WriteLine("api data:{0}", request.Serializable());
            Console.WriteLine("------------------");
            var response = client.Execute<K>(request);
            Console.WriteLine("return code:" + response.ResultCode);
            Console.WriteLine("return message:" + response.ReturnMsg);
            Assert.IsType<K>(response);
            var pro = response.GetType().GetProperties();
            foreach (var p in pro)
            {
                Console.WriteLine("{0}:{1}", p.Name, JsonConvert.SerializeObject(p.GetValue(response)));
            }
        }

        protected abstract T GetRequest();

        protected abstract string GetResponseXml();

        protected K ParseResponse(string xml)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
            var xs = new XmlSerializer(typeof(K), "");
            return (K)xs.Deserialize(stream);
        }
    }
}
