using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class UserInfoResponse : ApiResponse
    {
        public bool Subscribe { get; set; }

        public string OpenId { get; set; }

        public string Nickname { get; set; }

        public int Sex { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string Language { get; set; }

        public string Headimgurl { get; set; }

        public int Subscribe_time { get; set; }

        public string UnionID { get; set; }
    }
}
