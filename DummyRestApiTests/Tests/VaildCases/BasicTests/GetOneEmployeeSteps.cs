using NUnit.Framework;
using RestApiSender;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.BasicTests
{
    [Binding]
    public class GetOneEmployeeSteps
    {
        private readonly Sender sender = new Sender();
        private int employeeId;
        private SimplifiedResponseObject response;

        [Given(@"I want to retrive one employee with given id")]
        public void GivenIWantToRetriveOneEmployeeWithGivenId()
        {
            employeeId = 2;
        }

        [When(@"I send request to get one employee from the API")]
        public void WhenISendRequestToGetOneEmployeeFromTheAPI()
        {
            response = sender.MockOfGetOneEmployee(employeeId);
        }

        [Then(@"the get one employee response status should be (.*)")]
        public void ThenTheGetOneEmployeeResponseStatusShouldBeSuccess(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }

        [Then(@"the employee with given id should be returned")]
        public void ThenTheEmployeeWithGivenIdShouldBeReturned()
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(response.Data);
            var actualEmployeeId = Int32.Parse(jsonResponseData[0].ToString());
            var actualEmployeeName = jsonResponseData[1].ToString();

            Assert.AreEqual(employeeId, actualEmployeeId);
            Assert.AreEqual("Garrett Winters", actualEmployeeName);
        }
    }
}
