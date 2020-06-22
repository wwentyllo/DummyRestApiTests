using NUnit.Framework;
using RestApiSender;
using RestSharp;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.AdditionalCases
{
    [Binding]
    public class SalaryAsDoubleCreateAdditonalTestsSteps
    {
        private readonly Sender sender = new Sender();
        private Employee employee;
        private SimplifiedResponseObject response;
        private JsonObject jsonResponseData;

        [Given(@"I have a new employee object to add")]
        public void GivenIHaveANewEmployeeObjectToAdd()
        {
            employee = new Employee
            {
                Name = "test",
                Age = 27
            };
        }

        [Given(@"I have a salary with value: (.*)")]
        public void GivenIHaveASalaryWithValue(double salary)
        {
            employee.Salary = salary.ToString();
        }

        [When(@"I send create request with that employee object")]
        public void WhenISendCreateRequestWithThatEmployeeObject()
        {
            response = sender.CreateNewEmployee(employee);
        }

        [Then(@"The status of this operation should be (.*)")]
        public void ThenTheStatusOfThisOperationShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"I should retrive id")]
        public void ThenShouldRetriveId()
        {
            jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(response.Data);
            var actualId = jsonResponseData[3];
            Assert.IsNotNull(actualId);
        }

        [Then(@"Salary should be: (.*)")]
        public void ThenSalaryShouldBe(double excpectedSalary)
        {
            var actualSalary = jsonResponseData[1];

            Assert.AreEqual(excpectedSalary.ToString(), actualSalary);
        }
    }
}
