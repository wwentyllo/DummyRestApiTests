using NUnit.Framework;
using RestApiSender;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.BasicTests
{
    [Binding]
    public class UpdateEmployeeSteps
    {
        private readonly Sender sender = new Sender();
        private Employee updatedEmployee;
        private SimplifiedResponseObject response;
        private int empId;

        [Given(@"I have an id of employee who data I want to update - (.*)")]
        public void GivenIHaveAnIdOfEmployeeWhoDataIWantToUpdate(int id)
        {
            empId = id;
        }

        [When(@"I input new salary (.*)")]
        public void WhenITypeUpdatedDataForThisEmployee(string updatedSalary)
        {
            updatedEmployee = new Employee
            {
                Id = empId,
                Name = "Garrett Winters",
                Salary = updatedSalary,
                Age = 63
            };
        }

        [When(@"I send update request to the API")]
        public void WhenISendUpdateRequestToTheAPI()
        {
            response = sender.UpdateEmployee(updatedEmployee);
        }

        [Then(@"the update response status should be (.*)")]
        public void ThenTheUpdateResponseStatusShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"the employee with updated data should be returned")]
        public void ThenTheEmployeeWithUpdatedDataShouldBeReturned()
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(response.Data);

            var returnedEmployee = new Employee { Id = int.Parse(jsonResponseData[0].ToString()), Name = jsonResponseData[1].ToString(), Salary = jsonResponseData[2].ToString(), Age = int.Parse(jsonResponseData[3].ToString()) };

            Assert.AreEqual(updatedEmployee.Id, returnedEmployee.Id);
            Assert.AreEqual(updatedEmployee.Name, returnedEmployee.Name);
            Assert.AreEqual(updatedEmployee.Salary, returnedEmployee.Salary);
            Assert.AreEqual(updatedEmployee.Age, returnedEmployee.Age);
            Assert.AreEqual(updatedEmployee.Image, returnedEmployee.Image);

        }
    }
}
