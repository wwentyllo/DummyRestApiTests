using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases.DeleteEmployee
{
    [Binding]
    public class IdEqualToZeroDeleteEmployee_ErrorTestsSteps
    {
        private readonly Sender sender = new Sender();
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I have an id = (.*) as an id of the employee to delete")]
        public void GivenIHaveAnIdAsAndIdOfTheEmployeeToDelete(int id)
        {
            employeeId = id;
        }
        
        [When(@"I send request with this id to the API")]
        public void WhenISendRequestWithThisIdToTheAPI()
        {
            response = sender.DeleteEmployee(employeeId.ToString());
        }
        
        [Then(@"The error which indicates that it's not valid id should be returned")]
        public void ThenTheErrorWhichIndicatesThatItSNotValidIdShouldBeReturned()
        {
            var expectedError = "Error! Not able to delete record";
            var actualError = response.Message;

            Assert.AreEqual(expectedError, actualError);
        }
        
        [Then(@"The status of the RQ when id is equal to zero should be (.*)")]
        public void ThenTheStatusOfTheRQWhenIdIsEqualToZeroShouldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
