using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;

namespace WX.Api
{
    public class DefaultApiClient : IApiClient
    {
        public T Execute<T>(ApiRequest<T> request) where T : ApiResponse
        {
            request.Validate();

            return JsonConvert
                .DeserializeObject<T>(DoExecute(request));
        }

        public virtual string DoExecute<T>(ApiRequest<T> request)
            where T : ApiResponse
        {
            HttpWebRequest req = HttpWebRequest.Create(request.GetUrl())
                     as HttpWebRequest;

            if (req == null)
                throw new ArgumentException();

            req.Method = request.Method;

            if (req.Method == "POST")
            {
                var postdate = request.GetPostContent();
                Console.WriteLine(postdate);
                var postBytes = Encoding.UTF8.GetBytes(postdate);
                req.ContentType = "application/json; charset=utf-8";
                req.ContentLength = postBytes.Length;
                Stream stream = req.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();
            }

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode == HttpStatusCode.OK)
            {
                var stream = res.GetResponseStream();
                var reader = new System.IO.StreamReader(stream, Encoding.UTF8);
                var result = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                //res.Close();
                return result;
            }
            else
            {
                throw new WebException();
            }
        }
    }
}
