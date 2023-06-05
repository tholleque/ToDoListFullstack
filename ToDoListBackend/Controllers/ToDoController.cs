using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;

namespace ToDoListBackend.Controllers
{
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;
        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }
        
    }
}
