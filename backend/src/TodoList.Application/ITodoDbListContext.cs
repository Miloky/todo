using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoList.Domain;

namespace TodoList.Application
{
    public interface ITodoListDbContext
    {
        DbSet<TodoItem> TodoItems { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}