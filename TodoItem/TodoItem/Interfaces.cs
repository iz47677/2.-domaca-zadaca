using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Interfaces
{
    public interface ITodoRepository
    {
        TodoItem Get(Guid todoId);
        void Add(TodoItem todoItem);
        bool Remove(Guid todoId);
        void Update(TodoItem todoItem);
        bool MarkAsCompleted(Guid todoId);        List<TodoItem> GetAll();
        List<TodoItem> GetActive();
        List<TodoItem> GetCompleted();
        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }
}
