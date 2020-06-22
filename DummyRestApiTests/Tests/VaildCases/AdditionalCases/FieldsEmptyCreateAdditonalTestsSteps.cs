using DummyRestApiTests.Helpers;
using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.AdditionalCases
{
    [Binding]
    public class FieldsEmptyCreateAdditonalTestsSteps
    {
        private readonly Sender sender = new Sender();
        private readonly EmployeeParser parser = new EmployeeParser();
        private Employee employee;
        private SimplifiedResponseObject response;

        [Given(@"I have a new employee object wich has some fields empty")]
        public void GivenIHaveANewEmployeeObjectWichHasSomeFieldsEmpty()
        {
            employee = new Employee
            {
                Name = "",
                Salary = "",
                Age = 22
            };
        }

        [When(@"I send create request to the API")]
        public void WhenISendCreateRequestToTheAPI()
        {
            response = sender.CreateNewEmployee(employee);
        }

        [Then(@"the operation should be (.*)")]
        public void ThenTheOperationShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"I should retrive an id of the new employee")]
        public void ThenIShouldRetriveAnIdOfTheNewEmployee()
        {
            var actualId = parser.ParseAndReturnEmployeeFromCreateResponseObject(response).Id;

            Assert.IsNotNull(actualId);
        }
    }
}
