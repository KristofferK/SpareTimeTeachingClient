using SpareTimeTeachingClient.About;
using SpareTimeTeachingClient.Challenges;
using SpareTimeTeachingClient.User;
using SpareTimeTeachingClient.WebClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient
{
    public class SpareTimeTeachingFacade
    {
        private IWebClient webClient = new SmartWebClient();

        public string AboutSpareTimeTeaching()
        {
            return new AboutFetcher(webClient).Fetch();
        }

        public RegisterResponse Register(UserInformation user)
        {
            return new RegisterUser(webClient).Register(user);
        }

        public IEnumerable<ChallengeInformation> GetChallenges()
        {
            return new ChallengeFetcher(webClient).FetchAll();
        }
    }
}
