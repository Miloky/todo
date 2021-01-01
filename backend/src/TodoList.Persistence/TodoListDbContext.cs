using Microsoft.EntityFrameworkCore;
using TodoList.Application;
using TodoList.Domain;

namespace TodoList.Persistence 
{
    public class TodoListDbContext: DbContext, ITodoListDbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options)
        {
        }
        
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoListDbContext).Assembly);
        }
        
        
    }
}