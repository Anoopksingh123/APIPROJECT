using Microsoft.AspNetCore.Mvc;
using MVCWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCWeb.Controllers
{
    public class EmployeeController : Controller
    {
      
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44345/api/Employee/GetEmployee");
                //HTTP GET
                var responseTask = client.GetAsync("employees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    employees = (IEnumerable<Employee>)readTask.Result.AsEnumerable().ToList();
                }
                else //web api sent error response 
                {
                    //log response status here..

                    employees = Enumerable.Empty<Employee>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(employees);
        }
    }
}
