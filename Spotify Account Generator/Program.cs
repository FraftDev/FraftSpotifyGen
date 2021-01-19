using static Spotify_Account_Generator.Status;
using Spotify_Account_Generator.Utility;
using Spotify_Account_Generator.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spotify_Account_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "[FraftDev] Spotify Account Generator | V1.0 | https://twitter.com/FraftDev";
            Randomizer.LoadNames();

            if (!Directory.Exists(Environment.CurrentDirectory + "\\Export"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Export");

            UI.PrintUI();

            Console.Write("       How many Accounts do you want to generate: ", Console.ForegroundColor = ConsoleColor.White);
            int Amount;
            
            if (!int.TryParse(Console.ReadLine(), out Amount))
                Environment.Exit(0);

            Console.Clear();
            UI.PrintUI();

            DateTime CurrentDate = DateTime.Now;

            for (int i = 0; i < Amount; i++)
            {
                Account Account = new Account();
                Result Result = Account.Generate();

                if (Result != Result.Success)
                {
                    i--;
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"        [SUCCESS] {Account.Email}:{Account.Displayname}:{Account.Password}");
                Export.WriteLine(Environment.CurrentDirectory + $"\\Export\\Accounts_{CurrentDate.Day}_{CurrentDate.Month}_{CurrentDate.Year}.txt", Account.ToString());

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Environment.NewLine + $"                                                ~ GENERATED {Amount} ACCOUNTS ~");
            Console.ReadKey();
        }
    }
}
