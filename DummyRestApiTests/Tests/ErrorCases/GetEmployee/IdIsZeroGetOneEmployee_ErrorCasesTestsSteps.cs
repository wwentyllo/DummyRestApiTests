using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases.GetEmployee
{
    [Binding]
    public class IdIsZeroGetOneEmployee_ErrorCasesTestsSteps
    {
        private readonly Sender sender = new Sender();
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I have entered (.*) as an id of the employee to get")]
        public void GivenIHaveEnteredAsAnIdOfTheEmployeeToGet(int id)
        {
            employeeId = id;
        }

        [When(@"I send a request with id = 0 to the API")]
        public void WhenISendARequestWithIdToTheAPI()
        {
            response = sender.GetOneEmployee(employeeId);
        }

        [Then(@"The error should be returned for this operation")]
        public void ThenTheErrorShouldBeReturnedForThisOperation()
        {
            var expectedError = "Id is empty";
            var actualError = response.Message;

            Assert.AreEqual(expectedError, actualError);
        }

        [Then(@"The status should be (.*)")]
        public void ThenTheStatusShouldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
