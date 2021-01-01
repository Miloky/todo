using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Application;
using TodoList.Domain;

namespace TodoList.WebHost.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoListDbContext _context;

        public TodoItemController(ITodoListDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await  _context.TodoItems.ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TodoItemCreateCommand command)
        {
            var item = new TodoItem
            {
                Description = command.Description,
                Title = command.Title
            };
            await _context.TodoItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }

    public class TodoItemCreateCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoItemStatus Status { get; set; }
    }

    public enum TodoItemStatus
    {
        Todo,
        InProgress,
        Done
    }
}