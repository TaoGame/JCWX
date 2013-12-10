using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(RequestMessage req, ResponseMessage rep)
        {
            ReqMessage = req;
            RepMessage = rep;
        }

        public RequestMessage ReqMessage { get; set; }

        public ResponseMessage RepMessage { get; set; }
    }
}
