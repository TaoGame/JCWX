using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX.Logger
{
    public interface ILogger
    {
        void Log(string content);

        void Warn(string content);

        void Error(string content);

        void Exception(string content);
    }
}
