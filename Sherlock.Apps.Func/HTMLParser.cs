using HtmlAgilityPack;

namespace Sherlock.Apps.Func
{
    public class HTMLParser
    {
        private readonly HtmlDocument _htmlDoc;
        public HTMLParser(string html)
        {
            _htmlDoc = new HtmlDocument();
            _htmlDoc.LoadHtml(html);
        }

        public HtmlNode Document {
            get
            {
                return _htmlDoc.DocumentNode;
            } 
        }
    }
}
