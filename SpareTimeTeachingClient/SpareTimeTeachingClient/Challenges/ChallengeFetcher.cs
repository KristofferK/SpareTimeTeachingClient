using HtmlAgilityPack;
using SpareTimeTeachingClient.WebClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.Challenges
{
    internal class ChallengeFetcher
    {
        private const string BASE_URL = "http://sparetimeteaching.dk/challenges.php?sort=title&dir=ASC&offset=";
        private IWebClient webClient;
        public ChallengeFetcher(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public IEnumerable<ChallengeInformation> FetchAll()
        {
            int? offset = 0;
            var rows = new List<HtmlNode>();

            while (offset != null)
            {
                var tableRows = GetTableRows(offset.Value);
                if (tableRows.Count() != 0)
                {
                    offset += 10;
                    rows.AddRange(tableRows);
                }
                else
                {
                    offset = null;
                }
            }

            return rows.Select(htmlNode => GenerateChallenge(htmlNode));
        }

        private IEnumerable<HtmlNode> GetTableRows(int offset)
        {
            var source = webClient.Get(BASE_URL + offset);
            var htmlNode = HtmlNode.CreateNode(source);
            return htmlNode.SelectNodes("//table[@class='challenges']/tr").Skip(1).Reverse().Skip(1).Reverse();
        }

        private ChallengeInformation GenerateChallenge(HtmlNode htmlNode)
        {
            var rating = htmlNode.ChildNodes[2].InnerHtml.Split(new string[] { "<img src" }, StringSplitOptions.None).Length - 1;
            return new ChallengeInformation()
            {
                Language = htmlNode.ChildNodes[1].InnerText,
                Title = htmlNode.ChildNodes[0].InnerText,
                Rating = Convert.ToByte(rating),
                Link = "http://sparetimeteaching.dk/" + htmlNode.ChildNodes[0].ChildNodes[0].Attributes["href"].Value
            };
        }
    }
}
