using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UPS_.Models;

namespace UPS_.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://gorest.co.in/public/v2/";
        private const string AccessToken = "0bf7fb56e6a27cbcadc402fc2fce8e3aa9ac2b40d4190698eb4e8df9284e2023";

        public EmployeeService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {AccessToken}");
        }



        public async Task<List<Employee>> GetEmployeesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}users");

            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadFromJsonAsync<List<Employee>>();
                return employees;
            }

            return null;
        }

        public async Task<Employee> SearchEmployeesByNameAsync(string name)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}users?name={name}");
            if (response.IsSuccessStatusCode)
            {
                var employees = await response.Content.ReadFromJsonAsync<Employee>();
                return employees;
            }
            return null;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}users/{id}");
            if (response.IsSuccessStatusCode)
            {
                var employee = await response.Content.ReadFromJsonAsync<Employee>();
                return employee;
            }
            return null;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{BaseUrl}users", newEmployee);
            if (response.IsSuccessStatusCode)
            {
                var createdEmployee = await response.Content.ReadFromJsonAsync<Employee>();
                return createdEmployee;
            }

            return null;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{BaseUrl}users/{id}", updatedEmployee);

            if (response.IsSuccessStatusCode)
            {
                var updated = await response.Content.ReadFromJsonAsync<Employee>();
                return updated;
            }

            return null;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{BaseUrl}users/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
