Feature: DummyRestApiClient_BasicTests
	In order to check if API is working correctly
	I as a client
	I want to check if all CRUD operations are working correctly

@mytag
Scenario: Create new employee
	Given I have new employee object
	When  I send post request to the API
	Then the create response status should be success
	And new employee id should be returned 

Scenario: Get all employees
	Given I want to retrive list of all employees
	When I send get request to API for all employees
	Then the response status should be success
	And I should retrive the list of all employees
	And The list length should be 24

Scenario: Get one employee
	Given I want to retrive one employee with given id
	When I send request to get one employee from the API
	Then the get one employee response status should be success
	And  the employee with given id should be returned

Scenario: Update the employee data
	Given I have an id of employee who data I want to update - 2
	When I input new salary 1234
	And I send update request to the API
	Then the update response status should be success
	And the employee with updated data should be returned

Scenario: Delete the employee
	Given I have an employee to be deleted with given id: 98
	When I send delete request with given id to the API
	Then the delete operation should be success
	And a message should be retrned which indicates that the employee record is deleted