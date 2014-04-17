using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Model
{
    public class AppIdentication
    {
        public AppIdentication(string appId, string appSecret)
        {
            this.AppID = appId;
            this.AppSecret = appSecret;
        }

        public string AppID { get; set; }

        public string AppSecret { get; set; }
    }
}
