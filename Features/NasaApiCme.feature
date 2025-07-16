Feature: Coronal Mass Ejection API

@restAPi
Scenario: CME Success scenario
	Given the NASA Coronal Mass Ejection Endpoint with startDate, endDate,  and valid API Key
	When a GET request is sent 
	Then the response status code should be 200 
	And the response should contain a valid data of CME events

Scenario: CME Error Scenario
     Given the NASA endpoint with Incorrect date format
	 When a Get request is sent 
	 Then the response status code should be 400 
	 