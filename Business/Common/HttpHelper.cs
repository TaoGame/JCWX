using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace WX.Common
{
    public static class HttpHelper
    {
        public static string HttpUploadFile(string url, string file)
        {
            if (!File.Exists(file))
            {
                throw new FileNotFoundException();
            }

            FileInfo fileInfo = new FileInfo(file);


            string result = string.Empty;
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;

            var stream = request.GetRequestStream();
            stream.Write(boundarybytes, 0, boundarybytes.Length);

            var headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            var header = string.Format(headerTemplate, fileInfo.Name, file, GetContentType(fileInfo));
            var headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
            stream.Write(headerbytes, 0, headerbytes.Length);

            var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            var buffer = new byte[4096];
            var bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                stream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();

            var trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
            stream.Write(trailer, 0, trailer.Length);
            stream.Close();

            WebResponse wresp = null;
            try
            {
                wresp = request.GetResponse();

                Stream stream2 = wresp.GetResponseStream();
                StreamReader reader2 = new StreamReader(stream2);

                result = reader2.ReadToEnd();
            }
            finally
            {
                if (wresp != null)
                {
                    wresp.Close();
                    wresp = null;
                }
            }

            return result;
        }

        private static string GetContentType(FileInfo fileInfo)
        {
            var contentType = "";
            switch (fileInfo.Extension.ToLower())
            {
                case ".jpg":
                    contentType = "image/jpeg";
                    break;
                case ".mp3":
                    contentType = "audio/mp3";
                    break;
                case ".amr":
                    contentType = "audio/amr";
                    break;
                case ".mp4":
                    contentType = "video/mp4";
                    break;
                default:
                    throw new NotSupportedException("文件格式不支持");
            }

            return contentType;
        }

        public static string HttpGet(string url)
        {
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;

            if (req == null)
                throw new ArgumentException();
            req.Method = "GET";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode != HttpStatusCode.OK)
                throw new WebException("code" + res.StatusCode);
            using (var stream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
            {
                var result = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                //res.Close();

                return result;
            }
        }

        public static string HttpPost(string url, string content)
        {
            HttpWebRequest req = HttpWebRequest.Create(url)
                     as HttpWebRequest;

            if (req == null)
                throw new ArgumentException();
            var postdate = content;
            var postBytes = Encoding.UTF8.GetBytes(postdate);
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.ContentLength = postBytes.Length;
            Stream stream = req.GetRequestStream();
            stream.Write(postBytes, 0, postBytes.Length);
            stream.Close();

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode != HttpStatusCode.OK)
                throw new WebException("code" + res.StatusCode);


            using (var rstream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(rstream, Encoding.UTF8))
            {
                var result = reader.ReadToEnd();
                reader.Close();
                rstream.Close();

                //res.Close();
                return result;
            }
        }

        internal static string HttpGetFile(string url)
        {
            HttpWebRequest req = HttpWebRequest.Create(url)
                     as HttpWebRequest;

            if (req == null)
                throw new ArgumentException();
            req.Method = "GET";

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            if (res.StatusCode != HttpStatusCode.OK)
                throw new WebException("code" + res.StatusCode);
            using (var stream = res.GetResponseStream())
            using (var reader = new System.IO.StreamReader(stream, Encoding.UTF8))
            {
                var result = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                return result;
            }
        }
    }
}
