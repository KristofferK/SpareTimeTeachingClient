using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.Events
{
    public class EventInformation
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Host { get; set; }
        public string Date  { get; set; }
        public string WeekDay { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public string DownloadLink { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Type}) with {Host} at {Location}. {WeekDay} {Date}. {Link} {DownloadLink}";
        }
    }
}
