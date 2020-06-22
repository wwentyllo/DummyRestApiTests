Feature: DummyRestApiClient_FlowTests
	I order to use an API as a middleware
	layer in my web application
	I need to check some basic flow
	and how an API behaves when I do 
	some requests

@mytag
Scenario: Create, Update, Delete an employee
	Given I have a new employee whom I want to add
	When I create an employee
	And Later I update an employee
	And Next I delete an employee
	Then The delete operation should be successful

