using NUnit.Framework;
using RestApiSender;
using RestSharp;
using TechTalk.SpecFlow;

namespace DummyRestApiTests.Tests.VaildCases.AdditionalCases
{
    [Binding]
    public class EmptyJsonBodyUpdate_CreateAdditonalTestsSteps
    {
        private readonly Sender sender = new Sender();
        private SimplifiedResponseObject response;
        private int employeeId;
        private string jsonBody;

        [Given(@"I have entered (.*) as an employee id")]
        public void GivenIHaveEnteredAsAnEmployeeId(int id)
        {
            employeeId = id;
        }
        
        [Given(@"As a data to update I entered nothing \(empty Json body\) \('{}'\)")]
        public void GivenAsADataToUpdateIEnteredNothingEmptyJsonBody()
        {
             jsonBody = "{}";
        }
        
        [When(@"I send such request to the API endpoint")]
        public void WhenISendSuchRequestToTheAPIEndpoint()
        {
            response = sender.UpdateEmployeeWithJsonBody(employeeId, jsonBody);
        }
                
        [Then(@"the status for such operation should be (.*)")]
        public void ThenTheStatusForSuchOperationShouldBePassed(string expectedStatus)
        {
            var actualStatus = response.Status;

            Assert.AreEqual(expectedStatus, actualStatus);
        }
        
        [Then(@"I should have employee object only with Id returned")]
        public void ThenIShouldHaveEmployeeObjectOnlyWithIdReturned()
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(response.Data);
            var actualId = jsonResponseData[0];
            var actualName = jsonResponseData[1].ToString();

            Assert.IsNotNull(actualId);
            Assert.AreEqual(employeeId.ToString(), actualId);
            Assert.IsEmpty(actualName, "is not empty");
        }
    }
}
