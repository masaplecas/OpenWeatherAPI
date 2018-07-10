using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleJson;

namespace OpenWeatherAPITesting.Models
{
    [JsonObject]
    public class WeatherInfo
    {
        public Coord coord;

        public List<Weather> weather;

        public string @base;

        public Main main;

        public int visibility;

        public Wind wind;

        public Clouds clouds;

        public int dt;

        public Sys sys;

        public int id;

        public string name;

        public int cod;
    }

}