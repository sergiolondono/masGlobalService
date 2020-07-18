using MasGlobalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MasGlobalService.DAL
{
    public class EmployeeDAL
    {
        public IEnumerable<Employee> getEmployees()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");

                    HttpResponseMessage response = client.GetAsync("api/Employees").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // Parse the response body.
                        return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                    }
                    else
                    {
                        throw new Exception("Error getting data");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}