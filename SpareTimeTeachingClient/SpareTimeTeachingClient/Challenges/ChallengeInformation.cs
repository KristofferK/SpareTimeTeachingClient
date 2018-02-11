using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.Challenges
{
    public class ChallengeInformation
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public string Link { get; set; }
        public byte Rating { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Rating}*) | {Language} | {Link}";
        }
    }
}
