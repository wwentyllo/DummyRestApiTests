using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.ErrorCases
{
    [Binding]
    public class IdisEqualToZeroUpdate_ErrorTestsSteps
    {
        private readonly Sender sender = new Sender();
        private Employee realEmployeeData;
        private SimplifiedResponseObject response;
        private int employeeId;

        [Given(@"I entered (.*) as an id of the employee that I want to update")]
        public void GivenIEnteredAsAnIdOfTheEmployeeThatIWantToUpdate(int id)
        {
            employeeId = id;
        }
        
        [Given(@"I have a real data for the employee whom id is 23 in the Db")]
        public void GivenIHaveARealDataForTheEmployeeWhomIdIsInTheDb()
        {
            realEmployeeData = new Employee
            {
                Name = "Caesar Vance",
                Salary = "106450",
                Age = 21
            };
        }
        
        [When(@"I send the update request with id = 0 to the API endpoint")]
        public void WhenISendTheUpdateRequestWithIdToTheAPIEndpoint()
        {
            response = sender.UpdateEmployee(employeeId, realEmployeeData);
        }
        
        [Then(@"The error should be returned with message that for this id there is no record in Db")]
        public void ThenTheErrorShouldBeReturnedWithMessageThatForThisIdThereIsNoRecordInDb()
        {
            var expectedErrorMessage = "Record does not found.";
            var actualErrorMessage = response.Data;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
        
        [Then(@"The status for update with id equal to zero should be (.*)")]
        public void ThenTheStatusForUpdateWithIdEqualToZeroShouldBeFailed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
    }
}
