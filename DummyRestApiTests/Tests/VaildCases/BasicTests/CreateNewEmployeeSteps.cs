using TechTalk.SpecFlow;
using RestApiSender;
using NUnit.Framework;
using DummyRestApiTests.Helpers;

namespace DummyRestApiTests.Tests.VaildCases.BasicTests
{
    [Binding]
    class CreateNewEmployeeSteps
    {
        private readonly Sender sender = new Sender();
        private readonly EmployeeParser parser = new EmployeeParser();
        private Employee employee;
        private SimplifiedResponseObject response;

        [Given(@"I have new employee object")]
        public void GivenIHaveNewEmployeeObject()
        {
            employee = new Employee
            {
                Name = "test",
                Salary = "123",
                Age = 27
            };
        }

        [When(@"I send post request to the API")]
        public void WhenISendPostRequestToTheAPI()
        {
            response = sender.CreateNewEmployee(employee);
        }

        [Then(@"the create response status should be (.*)")]
        public void ThenTheCreateResponseStatusShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"new employee id should be returned")]
        public void ThenNewEmployeeIdShouldBeReturned()
        {
            var actualId = parser.ParseAndReturnEmployeeFromCreateResponseObject(response).Id;

            Assert.IsNotNull(actualId);
        }
    }
}
