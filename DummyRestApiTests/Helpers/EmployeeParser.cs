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
    }
}
