using HtmlAgilityPack;
using SpareTimeTeachingClient.WebClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.About
{
    internal class AboutFetcher
    {
        private IWebClient webClient;
        public AboutFetcher(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public string Fetch()
        {
            var source = webClient.Get("http://sparetimeteaching.dk/about.php");
            var node = HtmlNode.CreateNode(source).SelectSingleNode("//td[@class='content']");
            var about = node.InnerText.Trim();
            return Regex.Replace(about, "\n{3,}", "\n\n");
        }
    }
}
