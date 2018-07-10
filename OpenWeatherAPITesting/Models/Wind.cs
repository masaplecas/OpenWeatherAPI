using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenWeatherAPITesting.Models
{
    [JsonObject]
    public class Wind
    {
        public double speed;
        public int deg;
    }
}
