using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases.UpdateEmployee
{
    [Binding]
    public class IdIsLessThanZeroUpdate_ErrorTestsSteps
    {
        private readonly Sender sender = new Sender();
        private Employee realEmployeeData;
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I have entered (.*) as an id of the employee to check the system behavior")]
        public void GivenIHaveEnteredAsAnIdOfTheEmployeeToCheckTheSystemBehavior(int id)
        {
            employeeId = id;
        }
        
        [Given(@"I have also real data for the employee whom id is 23 in the Db")]
        public void GivenIHaveAlsoRealDataForTheEmployeeWhomIdIsInTheDb()
        {
            realEmployeeData = new Employee
            {
                Name = "Caesar Vance",
                Salary = "106450",
                Age = 21
            };
        }
        
        [When(@"I send next update request with id = -1 the the API endpoint")]
        public void WhenISendNextUpdateRequestWithIdTheTheAPIEndpoint()
        {
            response = sender.UpdateEmployee(employeeId, realEmployeeData);
        }
        
        [Then(@"The error should be returned with message that there is no record in Db with id = -1")]
        public void ThenTheErrorShouldBeReturnedWithMessageThatThereIsNoRecordInDbWithId()
        {
            var expectedErrorMessage = "Record does not found.";
            var actualErrorMessage = response.Data;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
        
        [Then(@"the status for update with id less than zero should be (.*)")]
        public void ThenTheStatusForUpdateWithIdLessThanZeroShouldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
