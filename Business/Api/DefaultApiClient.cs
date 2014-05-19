using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using WX.Common;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;

namespace WX.Api
{
    public class DefaultApiClient : IApiClient
    {
        public T Execute<T>(ApiRequest<T> request)
            where T : ApiResponse, new()
        {
            request.Validate();

            var execResult = DoExecute(request);
            T result = null;
            try
            {
                result = JsonConvert.DeserializeObject<T>(execResult);
            }
            catch(Exception ex)
            {
                result = null;
            }
            
            if (result == null )
            {
                if (request.NotHasResponse)
                {
                    return new T();
                }
                else
                {
                    throw new WebException();
                }
            }

            return result;
        }

        public virtual string DoExecute<T>(ApiRequest<T> request)
            where T : ApiResponse
        {
            //HttpWebRequest req = HttpWebRequest.Create(request.GetUrl())
            //         as HttpWebRequest;

            //if (req == null)
            //    throw new ArgumentException();

            var result = String.Empty;
            switch (request.Method)
            {
                case "FILE":
                    result = HttpHelper.HttpUploadFile(request.GetUrl(), request.GetPostContent());
                    break;
                case "POST":
                    result = HttpHelper.HttpPost(request.GetUrl(), request.GetPostContent());
                    break;
                case "GET":
                default:
                    result = HttpHelper.HttpGet(request.GetUrl());
                    break;
            }

            return result;

        }
    }
}
