using com.adtek.br.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Repository
{
    class TodoItemRepository
    {
        private readonly AdtekDBContext _context;

        public TodoItemRepository(AdtekDBContext context)
        {
            this._context = context;
        }

        public IEnumerable<TodoItem> GetTodoItems() 
        {
            return this._context.TodoItems.ToList();
        }

        public TodoItem? GetTodoItem(long id)
        {
            return this._context.TodoItems.Find(id);
        }

        public void Update(TodoItem todoItem)
        {
            this._context.Entry(todoItem).State = EntityState.Modified;
            this._context.SaveChanges();
        }

        public void Insert(TodoItem todoItem) 
        {
            this._context.TodoItems.Add(todoItem);
            this._context.SaveChanges();
        }

        public void Delete(TodoItem todoItem)
        {
            this._context.TodoItems.Remove(todoItem);
            this._context.SaveChanges();
        }

    }
}
