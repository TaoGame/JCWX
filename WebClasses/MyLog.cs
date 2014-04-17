using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WX.Demo.WebClasses
{
    public class MyLog
    {
        private static string fileName = HttpContext.Current.Server.MapPath("log.log");
        private static object lockobj = new object();

        public static void Log(string content)
        {
            lock (lockobj)
            {
                File.AppendAllText(fileName, content + "\r\n-----------------\r\n");
            }
        }
    }
}