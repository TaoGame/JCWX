using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WX.Common
{
    public static class DataSecret
    {
        public static string Md5(this string data)
        {
            var result = "";
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(data));

            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符

                result = result + s[i].ToString("X2");

            }

            return result;
        }
    }
}
