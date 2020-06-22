using RestApiSender;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyRestApiTests.Helpers
{
    public class EmployeeParser
    {
        public EmployeeParser()
        {

        }

        public List<Employee> ParseAndGetEmployeesFromResponse(SimplifiedResponseObject responseObject)
        {
            var returned = new List<Employee>();

            var jsonResponseData = (JsonArray)SimpleJson.DeserializeObject(responseObject.Data);

            foreach (JsonObject json in jsonResponseData)
            {
                returned.Add(new Employee
                {
                    Id = int.Parse(json[0].ToString()),
                    Name = json[1].ToString(),
                    Salary = json[2].ToString(),
                    Age = int.Parse(json[3].ToString()),
                    Image = json[4].ToString()
                });
            }

            return returned;
        }

        public Employee ParseAndReturnEmployeeFromCreateResponseObject(SimplifiedResponseObject responseObject)
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(responseObject.Data);

            if (responseObject.Data != null)
            {
                return new Employee
                {
                    Name = jsonResponseData[0].ToString(),
                    Salary = jsonResponseData[1].ToString(),
                    Age = Int32.Parse(jsonResponseData[2].ToString()),
                    Id = Int32.Parse(jsonResponseData[3].ToString())
                };
            }

            return null;
        }

        public Employee ParseAndReturnEmployeeFromGetAndUpdateResponseObject(SimplifiedResponseObject responseObject)
        {
            var jsonResponseData = (JsonObject)SimpleJson.DeserializeObject(responseObject.Data);

            if (responseObject.Data != null)
            {
                return new Employee
                {
                    Id = Int32.Parse(jsonResponseData[0].ToString()),
                    Name = jsonResponseData[1].ToString(),
                    Salary = jsonResponseData[2].ToString(),
                    Age = jsonResponseData[3] != null && jsonResponseData[3] != string.Empty ? Int32.Parse(jsonResponseData[3].ToString()) : 0,
                    Image = jsonResponseData.Count > 4 ?  jsonResponseData[4].ToString() : null
                };
            }

            return null;
        }       
    }
}
