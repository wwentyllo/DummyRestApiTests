using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases.GetEmployee
{
    [Binding]
    public class IdlessThanZeroGetEmployee_ErrorTestsSteps
    {
        private readonly Sender sender = new Sender();
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I have id = (.*) which is an id of employee whom I want to find")]
        public void GivenIHaveIdWhichIsAnIdOfEmployeeWhomIWantToFind(int id)
        {
            employeeId = id;
        }
        
        [When(@"I send the request with this id to the API")]
        public void WhenISendTheRequestWithThisIdToTheAPI()
        {
            response = sender.GetOneEmployee(employeeId);
        }
        
        [Then(@"The error should be returned with message that there is no record for this id")]
        public void ThenTheErrorShouldBeReturnedWithMessageThatThereIsNoRecordForThisId()
        {
            var expectedError = "Oops! someting issue found to fetch record.";
            var actualError = response.Message;

            Assert.AreEqual(expectedError, actualError);
        }
        
        [Then(@"The response status for this operation should be (.*)")]
        public void ThenTheResponseStatusForThisOperationShuldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
