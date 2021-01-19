using Spotify_Account_Generator.Utility;
using static Spotify_Account_Generator.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Account_Generator.Objects
{
    class Account
    {
        public string Username { get; set; }
        public string Displayname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string Country { get; set; }
        public string Logintoken { get; set; }

        public Account()
        {
            Displayname = Randomizer.RandomDisplayname();
            Gender = Randomizer.RandomGender();
            Email = Displayname + "@gmail.com";
            Password = Randomizer.RandomPassword();
            Birthdate = Randomizer.RandomBirthdate();
        }

        public override string ToString()
        {
            return $"{Email}:{Displayname}:{Username}:{Password}:{Gender}:{Country}:{Birthdate}:{Logintoken}";
        }

        public Result Generate()
        {
            try
            {
                HttpClient Client = new HttpClient();

                var ReqHeaders = new Dictionary<string, string>
                {
                    { "birth_day", Birthdate.Day.ToString() },
                    { "birth_month", Birthdate.Month.ToString() },
                    { "birth_year", Birthdate.Year.ToString() },
                    { "collect_personal_info", "undefined" },
                    { "creation_flow", "" },
                    { "creation_point", "https://www.spotify.com/de/signup/" },
                    { "displayname", Displayname },
                    { "email", Email },
                    { "gender", "male" },
                    { "iagree", "1" },
                    { "key", "a1e486e2729f46d6bb368d6b2bcda326" },
                    { "password", Password },
                    { "password_repeat", Password },
                    { "platform", "www" },
                    { "referrer", "" },
                    { "send-email", "0" },
                    { "thirdpartyemail", "0" },
                    { "fb", "0" }
                };
                var ReqContent = new FormUrlEncodedContent(ReqHeaders);

                var Response = Client.PostAsync("https://spclient.wg.spotify.com/signup/public/v1/account", ReqContent).Result;

                RegisterResponse ResponseJson = Newtonsoft.Json.JsonConvert.DeserializeObject<RegisterResponse>(Response.Content.ReadAsStringAsync().Result);

                if(ResponseJson.Status != 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"        [FAILURE] {Displayname}:{Password}");
                    return Result.Failure;
                }
                else
                {
                    Country = ResponseJson.Country;
                    Logintoken = ResponseJson.Logintoken;
                    Username = ResponseJson.Username;
                    return Result.Success;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"        [ERROR] {Displayname}:{Password} | Message: {ex.Message}");
                return Result.Error;
            }
        }
    }
}
