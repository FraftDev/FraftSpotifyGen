using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Account_Generator.Objects
{
    public class RegisterResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("dmca-radio")]
        public bool DmcaRadio { get; set; }

        [JsonProperty("shuffle-restricted")]
        public bool ShuffleRestricted { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
        public bool can_accept_licenses_in_one_step { get; set; }
        public bool requires_marketing_opt_in { get; set; }
        public bool requires_marketing_opt_in_text { get; set; }
        public int minimum_age { get; set; }
        public string country_group { get; set; }
        public bool specific_licenses { get; set; }
        public bool pretick_eula { get; set; }
        public bool show_collect_personal_info { get; set; }
        public bool use_all_genders { get; set; }
        public int date_endianness { get; set; }
        public bool is_country_launched { get; set; }

        [JsonProperty("login_token")]
        public string Logintoken { get; set; }
    }
}
