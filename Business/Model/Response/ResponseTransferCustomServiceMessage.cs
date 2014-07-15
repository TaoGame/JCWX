using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.Response
{
    public class ResponseTransferCustomServiceMessage : ResponseMessage
    {
         public ResponseTransferCustomServiceMessage() { }
         public ResponseTransferCustomServiceMessage(RequestMessage request)
            : base(request)
        {
        }

         public override MsgType MsgType
         {
             get
             {
                 return MsgType.transfer_customer_service;
             }
         }
    }
}
