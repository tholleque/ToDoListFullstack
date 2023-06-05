using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;

namespace ToDoListBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ToDoDbContext db = new ToDoDbContext();

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }
        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            Employee e = db.Employees.Find(id);
            return e;
        }
        [HttpPost]
        public void AddNewEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        
        //Cannot delete employees b/c of the forgein key
        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            Employee e = db.Employees.Find(id);
            db.Employees.Remove(e);
            db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateEmployee(Employee newEmployee, int id)
        {
            newEmployee.Id = id;
            db.Employees.Update(newEmployee);
            db.SaveChanges();
        }
    }
}
