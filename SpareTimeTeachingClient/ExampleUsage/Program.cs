using SpareTimeTeachingClient;
using SpareTimeTeachingClient.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUsage
{
    class Program
    {
        private static SpareTimeTeachingFacade spareTimeTeaching;

        static void Main(string[] args)
        {
            spareTimeTeaching = new SpareTimeTeachingFacade();
            RegisterAnUser();
            PrintAboutInformation();
            PrintChallenges();
        }

        static void PrintChallenges()
        {
            foreach (var challenge in spareTimeTeaching.GetChallenges())
            {
                Console.WriteLine(challenge);
            }
        }

        static void PrintAboutInformation()
        {
            var about = spareTimeTeaching.AboutSpareTimeTeaching();
            PrintUsingColor(about, ConsoleColor.Yellow);
        }

        static void RegisterAnUser()
        {
            var response = spareTimeTeaching.Register(new UserInformation()
            {
                Email = "test123456@email.com",
                Name = "Test Account123",
                Password = "123456"
            });
            var color = response.Success ? ConsoleColor.Green : ConsoleColor.Red;
            PrintUsingColor(response, color);
        }

        private static void PrintUsingColor(object o, ConsoleColor color)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(o);
            Console.ForegroundColor = currentColor;
        }
    }
}
