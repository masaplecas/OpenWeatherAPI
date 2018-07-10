using System;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeatherAPITesting.Models;
using RestSharp;
using RestSharp.Deserializers;
using SimpleJson;
using TechTalk.SpecFlow;

namespace OpenWeatherAPITesting.Steps
{
    [Binding]
    public class GetWeatherFeatureSteps
    {
        private RestClient _client;
        private RestRequest _request;
        private IRestResponse _response;

        [Given(@"I am connected to OpenWeatherAPI")]
        public void GivenIAmConnectedToOpenWeatherAPI()
        {
            _client= new RestClient("https://api.openweathermap.org/data/2.5/weather");
        }

        [Given(@"I created request")]
        public void GivenICreatedRequest()
        {
            _request= new RestRequest(Method.GET);
        }

        [Given(@"I passed Belgrade as city")]
        public void GivenIPassedBelgradeAsCity()
        {
            _request.AddParameter("q", "Belgrade");
           
        }
        
        [Given(@"I passed API key")]
        public void GivenIPassedAPIKey()
        {
            _request.AddParameter("APPID", "88e69d1f1a4a5888df2e5a370be64dde");
           
        }
        
        [Then(@"result should be response containing weather info")]
        public void ThenResultShouldBeResponseContainingWeatherInfo()
        {
            Assert.IsInstanceOfType(JsonConvert.DeserializeObject<WeatherInfo>(_response.Content), typeof(WeatherInfo));
           
        }

        [Then(@"result should be successful response")]
        public void ThenResultShouldBeSuccessfulResponse()
        {
            Assert.IsTrue(_response.IsSuccessful);
        }
        
        [When(@"I send request")]
        public void WhenISendRequest()
        {
            _response = _client.Execute(_request);
        }

    }
}
