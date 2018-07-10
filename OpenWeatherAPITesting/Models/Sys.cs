using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeatherAPITesting.Models
{
    [JsonObject]
    public class Sys
    {
        public int type;

        public int id;

        public string message;

        public string country;

        public int sunrise;

        public int sunset;
    }
}
