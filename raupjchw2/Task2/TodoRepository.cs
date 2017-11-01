using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException("Duplicate id: {" + todoItem.Id + "}");
            }
            else
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(t => t.Id == todoId);
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(i => !i.IsCompleted).ToList();
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(i => i.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(i => i.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem todoItem = (TodoItem)_inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
            if (todoItem == null)
            {
                return false;
            }
            else
            {
                if (todoItem.IsCompleted)
                {
                    return false;
                }
                else
                {
                    todoItem.MarkAsCompleted();
                    return true;
                }
            }
        }

        public bool Remove(Guid todoId)
        {
            TodoItem todoItem = (TodoItem)_inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
            if (todoItem == null)
            {
                return false;
            }
            else
            {
                _inMemoryTodoDatabase.Remove(todoItem);
                return true;
            }
        }

        public TodoItem Update(TodoItem todoItem)
        {
            _inMemoryTodoDatabase.Remove(todoItem);
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }
    }
}
