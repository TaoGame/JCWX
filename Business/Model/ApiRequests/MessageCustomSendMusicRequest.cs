using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiRequests
{
    public class MessageCustomSendMusicRequest : MessageCustomSendRequest
    {
        public override string MsgType
        {
            get { return "music"; }
        }

        public MusicMessage Music { get; set; }
    }
}
