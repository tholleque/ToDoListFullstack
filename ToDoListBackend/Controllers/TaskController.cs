using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;

namespace ToDoListBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ToDoDbContext db = new ToDoDbContext();

        [HttpGet]
        public List<ToDo> ToDoList()
        {
            return db.ToDos.ToList();
        }
        [HttpGet("{id}")]
        public ToDo GetTask(int id)
        {
            ToDo td = db.ToDos.Find(id);

            return td;
        }

        [HttpPost]
        public void CreateTask(ToDo newToDo)
        {
            db.ToDos.Add(newToDo);
            db.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void DeleteTask(int id)
        {
            ToDo td = db.ToDos.Find(id);
            db.ToDos.Remove(td);
            db.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateTask(ToDo newToDo, int id)
        {
            newToDo.Id = id;
            db.ToDos.Update(newToDo);
            db.SaveChanges();
        }
    }
}
