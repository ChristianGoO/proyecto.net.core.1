using com.adtek.br.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Repository
{
    public class TodoItemRepository
    {
        private readonly AdtekDBContext context;

        public TodoItemRepository(AdtekDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<TodoItem> GetTodoItems() 
        {
            return this.context.TodoItems.ToList();
        }

        public TodoItem? GetTodoItem(long id)
        {
            return this.context.TodoItems.Find(id);
        }

        public void Update(TodoItem todoItem)
        {
            this.context.Entry(todoItem).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Insert(TodoItem todoItem) 
        {
            this.context.TodoItems.Add(todoItem);
            this.context.SaveChanges();
        }

        public void Delete(TodoItem todoItem)
        {
            this.context.TodoItems.Remove(todoItem);
            this.context.SaveChanges();
        }

    }
}
