using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX
{
    public static class DateTimeExtend
    {
        private const long STANDARD_TIME_STAMP = 621355968000000000;

        public static long ConvertToTimeStamp(this DateTime time)
        {
            return (time.ToUniversalTime().Ticks - STANDARD_TIME_STAMP) / 10000000;
        }

        public static DateTime ConvertToDateTime(this long timestamp)
        {
            return new DateTime(timestamp * 10000000 + STANDARD_TIME_STAMP).ToLocalTime();
        }
    }
}
