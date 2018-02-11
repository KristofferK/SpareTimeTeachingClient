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
            Console.Title = "Spare Time Teaching Client";
            spareTimeTeaching = new SpareTimeTeachingFacade();
            while (true)
            {
                AskForUserInput();
            }
        }

        private static void AskForUserInput()
        {
            Console.Clear();
            PrintUsingColor("You've the following options:", ConsoleColor.Cyan);
            PrintUsingColor("[1] Register an user", ConsoleColor.Green);
            PrintUsingColor("[2] Fetch information about Spare Time Teaching", ConsoleColor.Green);
            PrintUsingColor("[3] Fetch a list of challenges", ConsoleColor.Green);
            PrintUsingColor("[4] Fetch a list of events", ConsoleColor.Green);

            var input = Console.ReadLine();
            if (input == "1")
            {
                PrintUsingColor("Name: ", ConsoleColor.Magenta, false);
                var name = Console.ReadLine();

                PrintUsingColor("Email: ", ConsoleColor.Magenta, false);
                var email = Console.ReadLine();

                PrintUsingColor("Password: ", ConsoleColor.Magenta, false);
                var password = Console.ReadLine();
                RegisterAnUser(name, email, password);
            }
            else if (input == "2")
            {
                PrintAboutInformation();
            }
            else if (input == "3")
            {
                PrintChallenges();
            }
            else if (input == "4")
            {
                PrintEvents();
            }
            else
            {
                return;  
            }
            Console.ReadLine();
        }

        static void PrintChallenges()
        {
            foreach (var challenge in spareTimeTeaching.GetChallenges())
            {
                Console.WriteLine(challenge);
            }
        }

        static void PrintEvents()
        {
            foreach (var events in spareTimeTeaching.GetEvents())
            {
                Console.WriteLine(events);
            }
        }

        static void PrintAboutInformation()
        {
            var about = spareTimeTeaching.AboutSpareTimeTeaching();
            PrintUsingColor(about, ConsoleColor.Yellow);
        }

        static void RegisterAnUser(string name, string email, string password)
        {
            var response = spareTimeTeaching.Register(new UserInformation()
            {
                Email = email,
                Name = name,
                Password = password
            });
            var color = response.Success ? ConsoleColor.Green : ConsoleColor.Red;
            PrintUsingColor(response, color);
        }

        private static void PrintUsingColor(object o, ConsoleColor color, bool breakline = true)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (breakline) Console.WriteLine(o);
            else Console.Write(o);
            Console.ForegroundColor = currentColor;
        }
    }
}
