using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Account_Generator.Utility
{
    public class Randomizer
    {
        private static Random _Random = new Random();
        private static string _Alphanumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static string _Numbers = "0123456789";
        private static List<string> _Malenames = new List<string>();
        private static List<string> _Femalenames = new List<string>();

        public static void LoadNames()
        {
            _Malenames = File.ReadAllLines(Environment.CurrentDirectory + "\\Data\\MaleNames.txt").ToList();
            _Femalenames = File.ReadAllLines(Environment.CurrentDirectory + "\\Data\\FemaleNames.txt").ToList();
        }

        public static DateTime RandomBirthdate()
        {
            DateTime Startdate = new DateTime(1970, 1, 1);
            int Range = (DateTime.Today - Startdate).Days - 5840; //16 Years Minimum
            return Startdate.AddDays(_Random.Next(Range));
        }

        public static string RandomDisplayname()
        {
            switch(_Random.Next(2))
            {
                case 0:
                    return _Malenames[_Random.Next(0, _Malenames.Count - 1)] + _Random.Next(100, 999);
                case 1:
                    return _Femalenames[_Random.Next(0, _Femalenames.Count - 1)] + _Random.Next(100, 999);
                default:
                    return _Malenames[_Random.Next(0, _Malenames.Count - 1)] + _Random.Next(100, 999);
            }
        }

        public static string RandomGender()
        {
            switch (_Random.Next(2))
            {
                case 0:
                    return "male";
                case 1:
                    return "female";
                default:
                    return "male";
            }
        }

        public static string RandomPassword(int Length = 12)
        {
            StringBuilder PasswordBuilder = new StringBuilder();
            for (int i = 0; i < Length; i++)
                PasswordBuilder.Append(_Alphanumeric[_Random.Next(0, _Alphanumeric.Length)]);

            return PasswordBuilder.ToString();
        }
    }
}
