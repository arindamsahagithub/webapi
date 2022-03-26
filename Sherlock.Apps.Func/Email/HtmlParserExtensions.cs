using System.Linq;
using HtmlAgilityPack;

namespace Sherlock.Apps.Func.Email
{
    public static class HtmlParserExtensions
    {
        #region elements
        public static HtmlNode GetElementById(this HtmlNode node, string id)
        {
            return node.SelectSingleNode($"//*[@id='{id}']");
        }

        public static HtmlNodeCollection GetElementsByClassName(this HtmlNode node, params string[] classes)
        {
            string xPath = string.Join("//*) and contains(@class, '", classes);
            return node.SelectNodes(xPath);
        }

        public static HtmlNode GetElementByText(this HtmlNode node, string text)
        {
            return node.SelectSingleNode($"//*[contains(text(),'{text}')]");
        }

        public static HtmlNode GetAnchorElementByHref(this HtmlNode node, string href)
        {
            return node.SelectSingleNode($"//a[contains(@href,'{href}')]");
        }

        public static HtmlNodeCollection GetElementsByText(this HtmlNode node, string text)
        {
            return node.SelectNodes($"//*[contains(text(),'{text}')]");
        }

        public static HtmlNode GetParentByTag(this HtmlNode node, string tagName)
        {
            return node.Ancestors().FirstOrDefault(n => n.Name == tagName);
        }

        public static HtmlNode GetDescendantsByTag(this HtmlNode node, string tagName)
        {
            return node.Descendants().FirstOrDefault(n => n.Name == tagName);
        }

        public static HtmlNode GetLastDescendantByTag(this HtmlNode node, string tagName)
        {
            return node.Descendants().LastOrDefault(n => n.Name == tagName);
        }
        #endregion

        #region attributes
        public static string GetValue(this HtmlNode node)
        {
            return node.Attributes["value"]?.Value;
        }
        #endregion
    }
}