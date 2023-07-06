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
    public class TodoItemService
    {
        private readonly TodoItemRepository repository;

        public TodoItemService(TodoItemRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TodoItemDto> GetTodoItems()
        {
            return this.repository.GetTodoItems().Select(todoItem => ItemToDTO(todoItem));
        }

        public TodoItemDto GetTodoItem(long id)
        {
            var todoItem = this.repository.GetTodoItem(id);

            if (todoItem == null)
                throw new Exception("No se encontro el registro");
            else
                return ItemToDTO(todoItem);
        }

        public void PutTodoItem(long id, TodoItemDto todoItemDto)
        { 
            if (id != todoItemDto.Id) 
            {
                throw new Exception("La peticion no es valida");
            }

            var todoItem = DtoToEntity(todoItemDto);
            this.repository.Update(todoItem);

        }

        public TodoItemDto PostTodoItem(TodoItemDto todoItemDto) 
        {
            var todoItem = DtoToEntity(todoItemDto);
            this.repository.Insert(todoItem);
            todoItemDto.Id = todoItem.Id;
            return todoItemDto;
        }

        public void DeleteTodoItem(long id) 
        {
            var todoItem = this.repository.GetTodoItem(id);
            if(todoItem == null)
            {
                throw new Exception("El registro no se encontro");
            }

            this.repository.Delete(todoItem);
        }

        private TodoItemDto ItemToDTO(TodoItem todoItem)
        {
            TodoItemDto dto = new TodoItemDto
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };

            return dto;
        }

        private TodoItem DtoToEntity(TodoItemDto todoItemDto)
        {
            TodoItem entinty = new TodoItem
            {
                Id = todoItemDto.Id,
                Name = todoItemDto.Name,
                IsComplete = todoItemDto.IsComplete
            };

            return entinty;
        }
    }
}
