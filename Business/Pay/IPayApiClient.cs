using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Pay.Request;
using WX.Pay.Response;

namespace WX.Pay
{
    public interface IPayApiClient
    {
        T Execute<T>(PayRequest<T> request) where T : PayResponse, new();
    }
}
