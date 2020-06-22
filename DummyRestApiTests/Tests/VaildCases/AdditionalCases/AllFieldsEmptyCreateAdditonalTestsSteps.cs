using DummyRestApiTests.Helpers;
using NUnit.Framework;
using RestApiSender;
using RestSharp;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.AdditionalCases
{
    [Binding]
    public class AllFieldsEmptyCreateAdditonalTestsSteps
    {
        private readonly Sender sender = new Sender();
        private readonly EmployeeParser parser = new EmployeeParser();
        private Employee employee;
        private SimplifiedResponseObject response;

        [Given(@"I have a new employee object which has all fields empty")]
        public void GivenIHaveANewEmployeeObjectWhichHasAllFieldsEmpty()
        {
            employee = new Employee();
        }

        [When(@"I send create request containing object with empty fields")]
        public void WhenISendCreateRequestContainingObjectWithEmptyFields()
        {
            response = sender.CreateNewEmployee(employee);
        }

        [Then(@"The operation result should be (.*)")]
        public void ThenTheOperationResultShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"I should retrive an id of newly created employee")]
        public void ThenIShouldRetriveAnIdOfNewlyCreatedEmployee()
        {
            var actualId = parser.ParseAndReturnEmployeeFromCreateResponseObject(response).Id;

            Assert.IsNotNull(actualId);
        }
    }
}
