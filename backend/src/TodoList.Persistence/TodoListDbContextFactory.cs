using Microsoft.EntityFrameworkCore;

namespace TodoList.Persistence
{
    public class TodoListDbContextFactory: DesignTimeDbContextFactoryBase<TodoListDbContext>
    {
        protected override TodoListDbContext CreateNewInstance(DbContextOptions<TodoListDbContext> options)
        {
           return new TodoListDbContext(options);
        }
    }
}