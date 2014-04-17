using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model.ApiResponses
{
    public class AccessTokenResponse : ApiResponse
    {
        public string Access_Token { get; set; }

        public int Expires_In { get; set; }

        public override string ToString()
        {
            if (IsError)
                return base.ToString();

            return String.Format("accesstoken:{0}, expires_in:{1}", Access_Token, Expires_In);
        }
    }
}
