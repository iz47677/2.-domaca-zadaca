using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Interfaces;
using GenericList;

namespace Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.Where(i => i.Id == todoId).FirstOrDefault();
        }

        public void Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
                throw new DuplicateTodoItemException(String.Format("duplicate id: {0}", todoItem.Id));
            else
                _inMemoryTodoDatabase.Add(todoItem);
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(this.Get(todoId));
        }

        public void Update(TodoItem todoItem)
        {
            _inMemoryTodoDatabase.Remove(todoItem);
            _inMemoryTodoDatabase.Add(todoItem);
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (this.Get(todoId) == null)
                return false;
            _inMemoryTodoDatabase.Where(i => i.Id == todoId).First().MarkAsCompleted();
            return true;
        }        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted == false).OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted == true).OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(i => filterFunction(i) == true).OrderByDescending(i => i.DateCreated).ToList();
        }
    }

    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException(string message) : base(message)
        {}
    }
}
