using NUnit.Framework;
using RestApiSender;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.BasicTests
{
    [Binding]
    public class DeleteEmployeeSteps
    {
        private readonly Sender sender = new Sender();
        private Employee employee;
        private SimplifiedResponseObject response;

        [Given(@"I have an employee to be deleted with given id: (.*)")]
        public void GivenIHaveAnEmployeeToBeDeleted(int id)
        {
            employee = new Employee()
            {
                Id = id,
            };
        }

        [When(@"I send delete request with given id to the API")]
        public void WhenISendDeleteRequestWithGivenIdToTheAPI()
        {
            response = sender.MockOfDeleteEmployee(employee.Id.ToString());
        }

        [Then(@"the delete operation should be (.*)")]
        public void ThenTheDeleteOperationShouldSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"a message should be retrned which indicates that the employee record is deleted")]
        public void ThenAMessageShouldBeRetrnedWhichIndicatesThatTheEmployeeRecordIsDeleted()
        {
            var excpectedMessage = "successfully! deleted Records";
            var actualMessage = response.Message;

            Assert.AreEqual(excpectedMessage, actualMessage);
        }
    }
}
