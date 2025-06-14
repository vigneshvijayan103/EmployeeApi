
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class EmployeesController : Controller
    {
        private static List<EmployeeService> Employeelist = new List<EmployeeService>()
        {
            new EmployeeService{Empid = 1,Name="abhi",Salary=25000},
            new EmployeeService{Empid = 2,Name="rahul",Salary=36000},
            new EmployeeService{Empid = 3,Name="varun",Salary=19000}
        };

        [HttpGet]

        public IActionResult Getall()
        {
            return Ok(Employeelist);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee([FromBody] EmployeeService newEmployee)
        {
            newEmployee.Empid = Employeelist.Count + 1;

            Employeelist.Add(newEmployee);

            return Ok("new employee added");

        }
        [HttpPut("{id}")]

        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeService UpdatedEmployee)
        {
            var employee = Employeelist.FirstOrDefault(p => p.Empid == id);

            if (employee == null)
            {
                return BadRequest("emmpoyee not found");
            }

            employee.Name = UpdatedEmployee.Name;
            employee.Salary = UpdatedEmployee.Salary;

            return Ok("updated succesfully...");
        }

        [HttpDelete("{id}")]

        public IActionResult deleteEmployee(int id)
        {
            var DeletedEmployee = Employeelist.FirstOrDefault(p => p.Empid == id);

            Employeelist.Remove(DeletedEmployee);

            return NoContent();
        }
    }
}
