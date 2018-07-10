using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenWeatherAPITesting.Models;
using RestSharp;
using RestSharp.Deserializers;
using SimpleJson;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

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
            _client = new RestClient("https://api.openweathermap.org/data/2.5/weather");
        }

        [Given(@"I created request")]
        public void GivenICreatedRequest()
        {
            _request = new RestRequest(Method.GET);

        }

        [Given(@"I passed API key")]
        public void GivenIPassedAPIKey()
        {
            _request.AddParameter("APPID", "88e69d1f1a4a5888df2e5a370be64dde");

        }

        [Given(@"I passed parameter (.*) and its value (.*)")]
        public void GivenIPassedParameterAndItsValue(string parameterName, string parameterValue)
        {
            _request.AddParameter(parameterName, parameterValue);
        }

        [When(@"I send request")]
        public void WhenISendRequest()
        {
            _response = _client.Execute(_request);
        }

        [Then(@"result should be response containing weather info")]
        public void ThenResultShouldBeResponseContainingWeatherInfo()
        {
            Assert.IsNotNull(CreateWeatherInfoObject(), "response json doesn't have all the values");
        }

        [Given(@"I passed city coordinates")]
        public void GivenIPassedCityCoordinates()
        {
            _request.AddParameter("lat", "44.8");
            _request.AddParameter("lon", "20.47");
        }


        #region Actions

        public WeatherInfo CreateWeatherInfoObject()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            WeatherInfo weatherinfo;
            try
            {
                weatherinfo = JsonConvert.DeserializeObject<WeatherInfo>(_response.Content, settings);
            }
            catch (JsonSerializationException)
            {

                weatherinfo = null;
            }
            return weatherinfo;


        }

        #endregion
    }




}

