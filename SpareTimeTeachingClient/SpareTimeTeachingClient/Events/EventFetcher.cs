using HtmlAgilityPack;
using SpareTimeTeachingClient.WebClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.Events
{
    internal class EventFetcher
    {
        private const string BASE_URL = "http://sparetimeteaching.dk/events.php?sort=date&dir=DESC&offset=";
        private const int ITEMS_PER_PAGE = 20;
        private IWebClient webClient;

        public EventFetcher(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public IEnumerable<EventInformation> FetchAll()
        {
            int? offset = 0;
            var rows = new List<HtmlNode>();

            while (offset != null)
            {
                var tableRows = GetTableRows(offset.Value);
                if (tableRows.Count() != 0)
                {
                    offset += ITEMS_PER_PAGE;
                    rows.AddRange(tableRows);
                }
                if (tableRows.Count() != ITEMS_PER_PAGE)
                {
                    offset = null;
                }
            }

            return rows.Select(htmlNode => GenerateEvent(htmlNode));
        }

        private IEnumerable<HtmlNode> GetTableRows(int offset)
        {
            var source = webClient.Get(BASE_URL + offset);
            var htmlNode = HtmlNode.CreateNode(source);
            return htmlNode.SelectNodes("//table[@style='width:100%;']/tr").Skip(1).Reverse().Skip(1).Reverse();
        }

        private EventInformation GenerateEvent(HtmlNode htmlNode)
        {
            var children = htmlNode.ChildNodes;
            var hasDownloadLink = children[5].HasChildNodes;
            return new EventInformation()
            {
                Title = children[0].InnerText,
                Type = children[1].InnerText,
                Host = children[2].InnerText,
                Date = children[3].InnerText,
                WeekDay = children[3].ChildNodes[0].Attributes["title"].Value,
                Location = children[4].InnerText,
                DownloadLink = hasDownloadLink ? "http://sparetimeteaching.dk/" + children[5].ChildNodes[0].Attributes["href"].Value : null,
                Link = "http://sparetimeteaching.dk/" + children[0].ChildNodes[0].ChildNodes[0].Attributes["href"].Value
            };
        }
    }
}
