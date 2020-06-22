
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RestApiSender
{

    public class Sender
    {
        private static readonly Uri baseUrl = new Uri("http://dummy.restapiexample.com/api/v1/");

        public SimplifiedResponseObject GetAllEmployees()
        {
            var returned = new List<Employee>();

             IRestClient client = new RestClient(baseUrl);
             IRestRequest request = new RestRequest("employees", Method.GET);
            IRestResponse<SimplifiedResponseObject> response = client.Execute<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {
                return response.Data;              
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }
        }

        public SimplifiedResponseObject GetOneEmployee(int id)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest($"employee/{id}",Method.GET);

            var response =  client.Get<SimplifiedResponseObject>(request);

            if (response.Data.Status.Equals("success"))
            {
                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject
                {
                    Error = response.ErrorMessage,
                    Message = response.Data.Message,
                    Status = response.Data.Status
                };
            }
        }

        public SimplifiedResponseObject MockOfGetOneEmployee(int id)
        {
           return new SimplifiedResponseObject
            {
                Data = "{\"id\":\""+id+"\",\"employee_name\":\"Garrett Winters\",\"employee_salary\":\"1232\",\"employee_age\":\"63\"}",
                Status = "success"
            };
        }

        public SimplifiedResponseObject MockOfGetOneEmployee(Employee createdEmployee)
        {
            return new SimplifiedResponseObject
            {
                Data = "{\"id\":\"" + createdEmployee.Id + "\",\"employee_name\":\"" + createdEmployee.Name + "\",\"employee_salary\":\"" + createdEmployee.Salary + "\",\"employee_age\":\""+ createdEmployee.Age + "\"}",
                Status = "success"
            };
        }

        public SimplifiedResponseObject CreateNewEmployee(Employee newEmployee)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest("create", Method.POST);

            var json = "{\"name\":\""+ newEmployee.Name + "\",\"salary\":\"" + newEmployee.Salary + "\",\"age\":\"" + newEmployee.Age.ToString() +"\"}";
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);

            IRestResponse<SimplifiedResponseObject> response = client.Post<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }          
        }

        public SimplifiedResponseObject DeleteEmployee(string id)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest($"delete/{id}", Method.DELETE);

            IRestResponse<SimplifiedResponseObject> response = client.Delete<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {              
                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }           
        }

        public SimplifiedResponseObject MockOfDeleteEmployee(string id)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest($"delete/{id}", Method.DELETE);

            IRestResponse<SimplifiedResponseObject> response = client.Delete<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {
                response.Data.Status = "success";
                response.Data.Message = "successfully! deleted Records";
                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }
        }

        public SimplifiedResponseObject UpdateEmployee(Employee employeeToUpdate)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest($"update/{employeeToUpdate.Id}", Method.PUT);

            var json = "{\"name\":\"" + employeeToUpdate.Name + "\",\"salary\":\"" + employeeToUpdate.Salary + "\",\"age\":\"" + employeeToUpdate.Age.ToString() + "\"}";
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);

            IRestResponse<SimplifiedResponseObject> response = client.Put<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {
                //it's a mock because data is not returned in the response
                response.Data.Data = "{\"id\":\"" + employeeToUpdate.Id + "\",\"employee_name\":\"" + employeeToUpdate.Name + "\",\"employee_salary\":\"" + employeeToUpdate.Salary + "\",\"employee_age\":\"" + employeeToUpdate.Age.ToString() + "\",\"profile_image\":\"" + employeeToUpdate.Image + "\"}";
                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }          
        }

        public SimplifiedResponseObject UpdateEmployee(int employeeId, Employee realEmployeeData)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest($"update/{employeeId}", Method.PUT);

            var json = "{\"name\":\"" + realEmployeeData.Name + "\",\"salary\":\"" + realEmployeeData.Salary + "\",\"age\":\"" + realEmployeeData.Age.ToString() + "\"}";
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);

            IRestResponse<SimplifiedResponseObject> response = client.Put<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {
                // I have to mock it because update response is always success without any data returned. maybe APi issue? 
                // Data below is exacly the same as returned in Postman
                response.Data.Data = "Record does not found.";
                response.Data.Status = "failed";

                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }
        }

        public SimplifiedResponseObject UpdateEmployeeWithJsonBody(int employeeId, string jsonBody)
        {
            IRestClient client = new RestClient(baseUrl);
            IRestRequest request = new RestRequest($"update/{employeeId}", Method.PUT);

            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(jsonBody);

            IRestResponse<SimplifiedResponseObject> response = client.Put<SimplifiedResponseObject>(request);

            if (response.IsSuccessful)
            {
                //it's a mock because data is not returned in the response
                // it's exacly the same what I have in Postman
                response.Data.Data = "{\"id\":\"" + employeeId + "\",\"employee_name\":\"" + String.Empty + "\",\"employee_salary\":\"" + String.Empty + "\",\"employee_age\":\"" + String.Empty + "\",\"profile_image\":\"" + String.Empty + "\"}";
                return response.Data;
            }
            else
            {
                return new SimplifiedResponseObject { Error = response.ErrorMessage };
            }
        }
    }
        class Program
        {
            static void Main(string[] args)
            {

            
            }
        }
}
