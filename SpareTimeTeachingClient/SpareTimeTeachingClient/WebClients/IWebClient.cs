using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.WebClients
{
    internal interface IWebClient
    {
        string Get(string url);
        string Post(string url, string payload);
    }
}
