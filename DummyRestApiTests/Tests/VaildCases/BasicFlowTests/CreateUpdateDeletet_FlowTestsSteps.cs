using NUnit.Framework;
using RestApiSender;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.BasicFlowTests
{
    [Binding]
    public class CreateUpdateDeletet_FlowTestsSteps
    {
        private readonly Sender sender = new Sender();
        private Employee newEmployee;
        private Employee employeeToUpdate;
        private SimplifiedResponseObject response;
        private SimplifiedResponseObject updateResponse;
        private SimplifiedResponseObject deleteResponse;
        private int createdEmployeeId;

        [Given(@"I have a new employee whom I want to add")]
        public void GivenIHaveANewEmployeeWhomIWantToAdd()
        {
            newEmployee = new Employee
            {
                Name = "New Employee",
                Salary = "1234",
                Age = 28
            };
        }
        
        [When(@"I create an employee")]
        public void WhenICreateAnEmployee()
        {
            response = sender.CreateNewEmployee(newEmployee);
        }
        
        [When(@"Later I update an employee")]
        public void WhenLaterIUpdateAnEmployee()
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(response.Data);
            var createEmployeeStatus = response.Status;

            Assert.AreEqual("success", createEmployeeStatus);

            createdEmployeeId = Int32.Parse(jsonResponseData[3].ToString());
            employeeToUpdate = new Employee
            {
                Id = createdEmployeeId,
                Name = newEmployee.Name,
                Salary = "3456",
                Age = newEmployee.Age
            };
            
            updateResponse = sender.UpdateEmployee(employeeToUpdate);
        }
        
        [When(@"Next I delete an employee")]
        public void WhenNextIDeleteAnEmployee()
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(updateResponse.Data);
            var updateEmployeeStatus = updateResponse.Status;

            Assert.AreEqual("success", updateEmployeeStatus);

            var updatedEmployeeId = Int32.Parse(jsonResponseData[0].ToString());
            var updatedEmployeeSalary = jsonResponseData[2].ToString();

            Assert.AreEqual(createdEmployeeId, updatedEmployeeId);
            Assert.AreNotEqual(newEmployee.Salary, updatedEmployeeSalary);

            deleteResponse = sender.MockOfDeleteEmployee(updatedEmployeeId.ToString());
        }
        
        [Then(@"The delete operation should be successful")]
        public void ThenTheDeleteOperationShouldBeSuccessful()
        {
            var expectedStatus = "success";
            var expectedMessage = "successfully! deleted Records";
            var actualStatus = deleteResponse.Status;
            var actualMessage = deleteResponse.Message;

            Assert.AreEqual(expectedStatus, actualStatus);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
