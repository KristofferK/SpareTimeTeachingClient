using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpareTimeTeachingClient.User
{
    internal static class UserToPayload
    {
        public static string GetPayloadForRegistering(UserInformation user)
        {
            return $"name={WebUtility.UrlEncode(user.Name)}" +
                $"&mail={WebUtility.UrlEncode(user.Email)}" +
                $"&password={WebUtility.UrlEncode(user.Password)}" +
                $"&repassword={WebUtility.UrlEncode(user.Password)}";
        }
    }
}
