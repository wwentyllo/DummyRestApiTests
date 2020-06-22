using NUnit.Framework;
using RestApiSender;
using RestSharp;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.AdditionalCases
{
    [Binding]
    public class LackOfSomeFieldsCreateAdditonalTestsSteps
    {
        private readonly Sender sender = new Sender();
        private Employee employee;
        private SimplifiedResponseObject response;

        [Given(@"I have a new employee object without some of the fields")]
        public void GivenIHaveANewEmployeeObjectWithoutSomeOfTheFields()
        {
            employee = new Employee
            {
                Salary = "123"
            };
        }

        [When(@"I send create request with that new employee object")]
        public void WhenISendCreateRequestWithThatEmployeeObject()
        {
            response = sender.CreateNewEmployee(employee);
        }

        [Then(@"The create operation should be (.*)")]
        public void ThenTheCreateOperationShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"I should retrive id of newly created employee")]
        public void ThenIShouldRetriveIdOfNewlyCreatedEmployee()
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(response.Data);
            var actualId = jsonResponseData[3];

            Assert.IsNotNull(actualId);
        }
    }
}
