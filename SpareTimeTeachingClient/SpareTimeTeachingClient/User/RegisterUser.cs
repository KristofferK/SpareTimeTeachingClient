using SpareTimeTeachingClient.WebClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.User
{
    internal class RegisterUser
    {
        private IWebClient webClient;

        public RegisterUser(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        public RegisterResponse Register(UserInformation user)
        {
            var response = webClient.Post("http://sparetimeteaching.dk/add_user.php", UserToPayload.GetPayloadForRegistering(user));
            var success = response.Length > 128;

            return new RegisterResponse()
            {
                Success = success,
                Message = success ? "Registered succesfully" : response
            };
        }
    }
}
