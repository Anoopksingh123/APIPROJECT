using APIPROJECT.Contract;
using APIPROJECT.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;



namespace APIPROJECT.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public AppDbContext DbContext { get; }
        private Response response = new Response();
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(AppDbContext dbContext, ILogger<EmployeeController> logger)
        {
            DbContext = dbContext;
            _logger = logger;

        }
        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetEmployee()
        {
            try
            {
                var Employees = DbContext.employees.ToList();
                response.Ok = true;
                response.Message = "Employee list found  !";
                response.Status = 200;
                response.data = Employees;


            }
            catch (Exception ex)
            {

                _logger.LogError(ex.ToString());
            }
            return Ok(response);


        }
        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult CreateEmployee(Employee employee)
        {
            try
            {
                DbContext.employees.Add(employee);
                DbContext.SaveChanges();
                response.Ok = true;
                response.Message = "Employee Details craeted succesfully  !";
                response.Status = 200;
                response.data = employee;
                return Ok(response);

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 500;
                response.Ok = false;
                _logger.LogError(ex.ToString());


            }
            return Ok(response);


        }
        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int Id)
        {
            var Emp = DbContext.employees.SingleOrDefault(e => e.Id == Id);
            if (Emp != null)
            {
                DbContext.employees.Remove(Emp);
                DbContext.SaveChanges();
                response.Ok = true;
                response.Status = 200;
                response.Message = "Employee  detail Deleted Successfully!";
            }
            else
            {
                response.Ok = false;
                response.Status = 404;
                response.Message = "Employee details Not Found !!";


            }
            return Ok(response);
        }
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                var emp = DbContext.employees.SingleOrDefault(e => e.Id == employee.Id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Email = employee.Email;
                    emp.Mobile = employee.Mobile;
                    emp.Gender = employee.Gender;
                    DbContext.employees.Update(emp);
                    DbContext.SaveChanges();
                    response.Ok = true;
                    response.Message = "Employee details Updated  succesfully  !";
                    response.Status = 200;
                    response.data = employee;

                }
                else
                {
                    response.Ok = false;
                    response.Message = "Employee details not found  !";
                    response.Status = 404;

                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = 500;
                response.Ok = false;
                _logger.LogError(ex.ToString());


            }
            return Ok(response);



        }
        [HttpPost]
        [Route("GetEmp")]
        public IActionResult GetEmp()
        {
            _logger.LogError("Fetching all the Employee from the storage");

            var emp = DbContext.employees.ToList();
            throw new Exception("Exception while fetching all the Employee from the storage.");
            _logger.LogError($"Returning {emp.Count} employee.");
            return Ok(emp);
        } 
    }
}
