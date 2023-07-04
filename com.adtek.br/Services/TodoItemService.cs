using com.adtek.br.Dtos;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    class TodoItemService
    {
        private readonly TodoItemRepository _repository;

        public TodoItemService(TodoItemRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<TodoItemDto> GetTodoItems()
        {
            return this._repository.GetTodoItems().Select(todoItem => ItemToDTO(todoItem));
        }

        public TodoItemDto GetTodoItem(long id)
        {
            return null;
        }

        public void PutTodoItem(long id, TodoItemDto todoItem)
        { 
        
        }

        public TodoItemDto PostTodoItem(TodoItemDto todoItem) 
        {
            return null;
        }


        public void DeleteTodoItem(long id) 
        {
        
        }

        private static TodoItemDto ItemToDTO(TodoItem todoItem) => new TodoItemDto
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };
    }
}
