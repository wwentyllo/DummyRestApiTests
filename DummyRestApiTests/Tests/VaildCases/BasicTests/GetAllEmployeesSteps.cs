using DummyRestApiTests.Helpers;
using NUnit.Framework;
using RestApiSender;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.BasicTests
{
    [Binding]
    public class GetAllEmployeesSteps
    {     
        private readonly Sender sender = new Sender();
        private readonly EmployeeParser employeeParser = new EmployeeParser();
        private SimplifiedResponseObject response;
        private List<Employee> actualEmployeeList;

        [Given(@"I want to retrive list of all employees")]
        public void GivenIWantToRetriveListOfAllEmployees()
        {
            actualEmployeeList = new List<Employee>();
        }

        [When(@"I send get request to API for all employees")]
        public void WhenISendGetRequestToAPIForAllEmployees()
        {
            response = sender.GetAllEmployees();
        }

        [Then(@"the response status should be (.*)")]
        public void ThenTheResponseStatusShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;
            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"I should retrive the list of all employees")]
        public void ThenIShouldRetriveListOfAllEmployees()
        {
            actualEmployeeList = employeeParser.ParseAndGetEmployeesFromResponse(response);

            Assert.IsNotNull(actualEmployeeList);
        }

        [Then(@"The list length should be (.*)")]
        public void ThenTheIstLengthShouldBe(int expectedListLength)
        {
            Assert.AreEqual(expectedListLength, actualEmployeeList.Count);
        }
    }
}
