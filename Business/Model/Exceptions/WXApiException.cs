using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.Exceptions
{
    public class WXApiException : Exception
    {
        public WXApiException(int code, string content)
        {
            Code = code;
            Content = content;
        }

        public int Code { get; set; }

        public string Content { get; set; }
    }
}
