Feature: DummyRestApiClient_ErrorTests
	In order to check if API is working correctly
	I as a client
	I want to check if API is resistant to
	invalid requests

@mytag
Scenario: Get One Employee - id is less then zero
	Given I have id = -1 which is an id of employee whom I want to find
	When I send the request with this id to the API
	Then The error should be returned with message that there is no record for this id
	And The response status for this operation should be failed

Scenario: Get One Employee - id = 0
	Given I have entered 0 as an id of the employee to get
	When I send a request with id = 0 to the API
	Then The error should be returned for this operation
	And The status should be failed

Scenario: Get One Employee - id not found
	Given I have entered 99 as an id of the employee and this id should not be found
	When I send a request with id not present in DB to the API
	Then The error should be returned for this operation indicates that there is no record
	And The status for this case should be failed	

Scenario: Delete Employee - id not found
	Given I have entered 999 as an id of the employee whom I want to delete
	When I send delete request with id which is not found to the API
	Then The error should be returned for id = 999
	And The status when id == 999 should be failed 

Scenario: Delete Employee - id < 0
	Given I have entered -1 as an id of the employee whom I want to delete when id < 0
	When I send delete request with id < 0 to the API
	Then The error should be returned for id = -1
	And The status when id = -1 should be failed 

Scenario: Delete Employee - id is equal to zero
	Given I have an id = 0 as an id of the employee to delete
	When I send request with this id to the API
	Then The error which indicates that it's not valid id should be returned
	And The status of the RQ when id is equal to zero should be failed

Scenario: Update Employee - id is equal to zero
	Given I entered 0 as an id of the employee that I want to update
	And I have a real data for the employee whom id is 23 in the Db
	When I send the update request with id = 0 to the API endpoint
	Then The error should be returned with message that for this id there is no record in Db
	And The status for update with id equal to zero should be failed

Scenario: Update Employee - id is less than zero
	Given I have entered -1 as an id of the employee to check the system behavior
	And I have also real data for the employee whom id is 23 in the Db
	When I send next update request with id = -1 the the API endpoint
	Then The error should be returned with message that there is no record in Db with id = -1
	And the status for update with id less than zero should be failed