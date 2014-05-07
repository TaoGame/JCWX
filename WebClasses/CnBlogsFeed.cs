using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using WX.Model;

namespace WX.Demo.WebClasses
{
    public class CnBlogsFeed
    {
        private int m_topNum = 5;

        //缓存过期时间，这里是10分钟
        private static int s_timeout = 10 * 60 * 1000;
        //缓存过期时间
        private static DateTime s_outDate = DateTime.Now;
        //博客园文章列表正则表达式
        private static Regex s_cnblogsIndexRegex = new Regex("<div\\s*class=\"post_item\">\\s*.*\\s*.*\\s*.*\\s*.*\\s*.*\\s*.*\\s*.*\\s*<div\\s*class=\"post_item_body\">\\s*<h3><a\\s*class=\"titlelnk\"\\s*href=\"(?<href>.*)\"\\s*target=\"_blank\">(?<title>.*)</a>.*\\s*<p\\s*class=\"post_item_summary\">\\s*(?<content>.*)\\s*</p>");
        //内容中，用户头像正则表达式
        private static Regex s_picUrlRegex = new Regex("src=\"(?<picurl>.*)\"\\s");
        //博客园文章列表uri
        private static string s_cnblogsIndexUri = "http://www.cnblogs.com/mvc/AggSite/PostList.aspx?CategoryId=808&PageIndex=1";
        //默认的一个大图，一个小图的图片地址
        private static string s_defaultBigPicUri = "http://wx.jamesying.com/images/default_title.jpg";
        private static string s_defaultSmallPicUri = "http://wx.jamesying.com/images/default_small.jpg";

        //用来缓存请求过来的数据，不高兴用Cache了。
        private static List<ArticleMessage> s_articles = null;

        public CnBlogsFeed(int topNum)
        {
            m_topNum = topNum;
        }

        public List<ArticleMessage> GetTopCnblogsFeed()
        {
            if (s_articles == null)
            {
                GetTopCnblogsFeed(m_topNum);
            }
            else
            {
                if (DateTime.Now > s_outDate)
                {
                    GetTopCnblogsFeed(m_topNum);
                }
            }

            return s_articles;
        }

        private void GetTopCnblogsFeed(int m_topNum)
        {
            try
            {
                var html = GetRemoteUri(s_cnblogsIndexUri, Encoding.UTF8);
                var matchs = s_cnblogsIndexRegex.Matches(html);
                var i = 0;
                s_articles = new List<ArticleMessage>();
                foreach (Match match in matchs)
                {
                    if (i >= m_topNum)
                        break;
                    var article = new ArticleMessage
                    {
                        Title = match.Groups[2].Value,
                        Url = match.Groups[1].Value,
                        Description = match.Groups[3].Value
                    };

                    if (i == 0)
                    {
                        article.PicUrl = s_defaultBigPicUri;
                    }
                    else
                    {
                        var matchPic = s_picUrlRegex.Match(article.Description);
                        if (matchPic.Success)
                        {
                            article.PicUrl = matchPic.Groups[1].Value;
                        }
                        else
                        {
                            article.PicUrl = s_defaultSmallPicUri;
                        }
                    }

                    s_articles.Add(article);

                    i += 1;
                }

                s_outDate = DateTime.Now.AddMilliseconds(s_timeout);
            }
            catch(Exception ex)
            {
                s_articles = null;
                s_outDate = DateTime.Now;
#if DEBUG
                throw ex;
#endif
            }

            //return s_articles;
        }

        private string GetRemoteUri(string uri, Encoding encoding)
        {
            var client = new WebClient();
            client.Encoding = encoding;

            return client.DownloadString(uri);
        }
    }
}