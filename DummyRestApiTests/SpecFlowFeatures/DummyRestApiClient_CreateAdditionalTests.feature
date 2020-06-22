Feature: DummyRestApiClient_CreateAdditonalTests
	In order to check if API is working correctly
	I as a client
	I want to check if other not obvious cases 
	are woring correctly

@mytag
Scenario: Create New Employee - some of fields empty
	Given I have a new employee object wich has some fields empty
	When I send create request to the API
	Then the operation should be success
	And I should retrive an id of the new employee

Scenario: Create New Employee - all fields empty
	Given I have a new employee object which has all fields empty
	When I send create request containing object with empty fields
	Then The operation result should be success 
	And I should retrive an id of newly created employee

Scenario: Create New Employee - lack of some fields
	Given I have a new employee object without some of the fields
	When I send create request with that new employee object
	Then The create operation should be success
	And I should retrive id of newly created employee

Scenario: Create New Employee - salary with type double
	Given I have a new employee object to add
	And I have a salary with value: 123.333
	When I send create request with that employee object
	Then The status of this operation should be success
	And I should retrive id
	And Salary should be: 123.333

Scenario: Update Employee - empty Json body
	Given I have entered 24 as an employee id
	And As a data to update I entered nothing (empty Json body) ('{}')
	When I send such request to the API endpoint
	Then the status for such operation should be success
	And I should have employee object only with Id returned 