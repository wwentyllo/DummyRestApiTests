using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases.DeleteEmployee
{
    [Binding]
    public class IdLessThenZero_ErrorCasesTestsSteps
    {
        private readonly Sender sender = new Sender();
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I have entered (.*) as an id of the employee whom I want to delete when id < 0")]
        public void GivenIHaveEnteredAsAnIdOfTheEmployeeWhomIWantToDeleteWhenId(int id)
        {
            employeeId = id;
        }

        [When(@"I send delete request with id < 0 to the API")]
        public void WhenISendDeleteRequestWithIdToTheAPI()
        {
            response = sender.DeleteEmployee(employeeId.ToString());
        }

        [Then(@"The error should be returned for id = -1")]
        public void ThenTheErrorShouldBeReturnedForId()
        {
            var expectedError = "Error! Not able to delete record";
            var actualError = response.Message;

            Assert.AreEqual(expectedError, actualError);
        }

        [Then(@"The status when id = -1 should be (.*)")]
        public void ThenTheStatusWhenIdShouldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
