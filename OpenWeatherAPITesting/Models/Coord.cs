using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeatherAPITesting.Models
{
    [JsonObject]

    public class Coord
    {

        public double lon;

        public double lat;


    }
}
