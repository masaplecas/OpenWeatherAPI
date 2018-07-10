Feature: GetWeatherFeature
	In order to easy access weather data
	As a user
	I want to get weather by calling API


Scenario Outline: Get weather info
	Given I am connected to OpenWeatherAPI
	And I created request
	And I passed parameter <ParameterName> and its value <ParameterValue>	
	And I passed API key	
	When I send request
	Then result should be response containing weather info
Examples: 
	| ParameterName | ParameterValue |
	| q             | Belgrade       |
	| id            | 792680         |
	| zip           | 94040,us       |

Scenario: Get weather info using city coordinates
	Given I am connected to OpenWeatherAPI
	And I created request
	And I passed city coordinates
	And I passed API key	
	When I send request
	Then result should be response containing weather info