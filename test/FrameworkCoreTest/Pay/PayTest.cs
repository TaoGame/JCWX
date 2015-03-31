using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Pay.Request;
using WX.Pay.Response;
using Xunit;

namespace FrameworkCoreTest.Pay
{
    public abstract class PayTest<T, K>
        where T : PayRequest
        where K : PayResponse
    {
        [Fact]
        public void StepTest()
        {
            T request = GetRequest();
            Console.WriteLine("step start......");
            Console.WriteLine("api url:{0}", request.Url);
            Console.WriteLine("api data:{0}", request.Serializable());
            Console.WriteLine("------------------");
            var xml = GetResponseXml();
            Console.WriteLine("api response:{0}", xml);
            Assert.IsType<K>(ParseResponse(xml));
        }

        protected abstract T GetRequest();

        protected abstract string GetResponseXml();

        protected abstract K ParseResponse(string xml);
    }
}
