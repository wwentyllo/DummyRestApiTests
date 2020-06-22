using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases.GetEmployee
{
    [Binding]
    public class IdNotFoundGetEmployee_ErrorCasesTestsSteps
    {
        private readonly Sender sender = new Sender();
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I have entered (.*) as an id of the employee and this id should not be found")]
        public void GivenIHaveEnteredAsAnIdOfTheEmployeeAndThisIdShouldNotBeFound(int id)
        {
            employeeId = id;
        }
        
        [When(@"I send a request with id not present in DB to the API")]
        public void WhenISendARequestWithIdNotPresentInDBToTheAPI()
        {
            response = sender.GetOneEmployee(employeeId);
        }
        
        [Then(@"The error should be returned for this operation indicates that there is no record")]
        public void ThenTheErrorShouldBeReturnedForThisOperationIndicatesThatTehreIsNoRecord()
        {
            var expectedError = "Oops! someting issue found to fetch record.";

            var actualError = response.Message;

            Assert.AreEqual(expectedError, actualError);
        }
        
        [Then(@"The status for this case should be (.*)")]
        public void ThenTheStatusForThisCaseShouldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
