using DummyRestApiTests.Helpers;
using NUnit.Framework;
using RestApiSender;
using System;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.BasicTests
{
    [Binding]
    public class UpdateEmployeeSteps
    {
        private readonly Sender sender = new Sender();
        private readonly EmployeeParser parser = new EmployeeParser();
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
            var returnedEmployee = parser.ParseAndReturnEmployeeFromGetAndUpdateResponseObject(response);

            Assert.AreEqual(updatedEmployee.Id, returnedEmployee.Id);
            Assert.AreEqual(updatedEmployee.Name, returnedEmployee.Name);
            Assert.AreEqual(updatedEmployee.Salary, returnedEmployee.Salary);
            Assert.AreEqual(updatedEmployee.Age, returnedEmployee.Age);
            Assert.AreEqual(String.Empty, returnedEmployee.Image);

        }
    }
}
