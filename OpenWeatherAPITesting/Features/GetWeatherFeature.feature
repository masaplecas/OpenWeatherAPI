Feature: GetWeatherFeature
	In order to easy access weather data
	As a user
	I want to get weather by calling API

@test
Scenario: Get response successfully
	Given I am connected to OpenWeatherAPI
	And I created request
	And I passed Belgrade as city
	And I passed API key	
	When I send request
	Then result should be successful response

@test
Scenario: Get weather info
	Given I am connected to OpenWeatherAPI
	And I created request
	And I passed Belgrade as city
	And I passed API key	
	When I send request
	Then result should be response containing weather info
