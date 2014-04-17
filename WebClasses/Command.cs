using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX.Framework;

namespace WX.Demo.WebClasses
{
    public class Command
    {
        public string Keywords { get; set; }

        public string Parameter { get; set; }

        public IMessageHandler MessageHandler { get; set; }
    }
}
