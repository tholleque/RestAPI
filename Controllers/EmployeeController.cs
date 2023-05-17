using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        NorthwndContext db = new NorthwndContext();

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }
        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            Employee output = db.Employees.Find(id);
            if (output != null)
            {
                return output;
            }
            else
            {
                return new Employee()
                {
                    LastName = $"Error: id {id} is not a valid id in the db please try again",
                };
            }
        }
        [HttpGet("Country/{country}")]
        // only has USA and UK...
        public List<Employee> GetEmployeeByCountry(string country) 
        { 
            List<Employee> employeeByCountry = db.Employees.Where(e => e.Country == country).ToList();
            return employeeByCountry;
        }
    }
}
