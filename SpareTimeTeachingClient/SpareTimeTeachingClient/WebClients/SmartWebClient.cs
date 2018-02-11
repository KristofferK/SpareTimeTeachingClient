using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.WebClients
{
    internal class SmartWebClient : IWebClient
    {
        public string Get(string url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.UserAgent] = "Spare Time Teaching Client";
                return wc.DownloadString(url);
            }
        }

        public string Post(string url, string payload)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.UserAgent] = "Spare Time Teaching Client";
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                wc.Encoding = Encoding.UTF8;
                return wc.UploadString(url, payload);
            }
        }
    }
}
