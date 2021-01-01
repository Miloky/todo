using System.Collections.Generic;

namespace TodoList.Domain
{
    public class User
    {
        public User()
        {
            TodoItems = new HashSet<TodoItem>();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<TodoItem>  TodoItems { get; set; }
    }
}