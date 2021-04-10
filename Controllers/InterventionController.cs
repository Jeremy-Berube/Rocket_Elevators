using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Rocket_Elevators_Customer_Portal.Areas.Identity.Data;
using System.Net.Http;


namespace Rocket_Elevators_Customer_Portal.Controllers
{
    [Authorize]
    public class InterventionController : Controller
    {
        HttpClient client = new HttpClient();
      
        public IActionResult Index()
        {
            return View();
        }
        public async Task<dynamic> GetCustomerId()
        {

            Console.WriteLine(User.Identity.Name);
            HttpResponseMessage Response = await client.GetAsync($"https://wsjeremy.azurewebsites.net/api/Customers/{User.Identity.Name}/id");
            var EmpResponse = Response.Content.ReadAsStringAsync().Result;
 
            return EmpResponse;
        }
        public async Task<dynamic> GetBuildings()
        {
            var id = await GetCustomerId();
            HttpResponseMessage Response = await client.GetAsync($"https://wsjeremy.azurewebsites.net/api/Buildings/{id}");
            var EmpResponse = Response.Content.ReadAsStringAsync().Result;

            return EmpResponse;
        }
        public async Task<dynamic> GetBatteries(string id)
        {
            
            HttpResponseMessage Response = await client.GetAsync($"https://wsjeremy.azurewebsites.net/api/Batteries/{id}");
            var EmpResponse = Response.Content.ReadAsStringAsync().Result;

            return EmpResponse;
        }
        public async Task<dynamic> GetColumns(string id)
        {
            
            HttpResponseMessage Response = await client.GetAsync($"https://wsjeremy.azurewebsites.net/api/Columns/{id}");
            var EmpResponse = Response.Content.ReadAsStringAsync().Result;

            return EmpResponse;
        }
        public async Task<dynamic> GetElevators(string id)
        { 
            HttpResponseMessage Response = await client.GetAsync($"https://wsjeremy.azurewebsites.net/api/Elevators/{id}");
            var EmpResponse = Response.Content.ReadAsStringAsync().Result;

            return EmpResponse;
        }

    }
}