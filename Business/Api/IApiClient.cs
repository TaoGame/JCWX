using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Model.ApiRequests;
using WX.Model.ApiResponses;

namespace WX.Api
{
    public interface IApiClient
    {
        T Execute<T>(ApiRequest<T> request) where T : ApiResponse, new();
    }
}
