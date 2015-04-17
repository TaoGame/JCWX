using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX.Logger;

namespace FrameworkCoreTest
{
    public class Logger : ILogger
    {
        public void Log(string content)
        {
            Console.WriteLine("log:" + content);
        }

        public void Warn(string content)
        {
            Console.WriteLine("Warn:" + content);
        }

        public void Error(string content)
        {
            Console.WriteLine("Error:" + content);
        }

        public void Exception(string content)
        {
            Console.WriteLine("Exception:" + content);
        }
    }
}
