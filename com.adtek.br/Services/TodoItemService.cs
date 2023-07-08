using com.adtek.br.Dtos;
using com.adtek.br.Exceptions;
using com.adtek.br.Models;
using com.adtek.br.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    public class TodoItemService : Service
    {
        private readonly TodoItemRepository repository;

        public TodoItemService(TodoItemRepository repository)
        {
            this.repository = repository;
        }

        public Result<TodoItemDto> GetTodoItems()
        {
            Result<TodoItemDto> result = new Result<TodoItemDto>();
            try 
            {
                result.Resultados = this.repository.GetTodoItems().Select(todoItem => ItemToDTO(todoItem));
                result.ConsultaExitosa();
            }
            catch (Exception ex)
            {
                result = this.GeneraError<TodoItemDto>(ex);
            }

            return result;
        }

        public Result<TodoItemDto> GetTodoItem(long id)
        {
            Result<TodoItemDto> result = new Result<TodoItemDto>();
            try 
            {
                var todoItem = this.repository.GetTodoItem(id);

                if (todoItem == null)
                    throw new NotFoundException("No se encontro el registro");
                else
                    result.Resultado = this.ItemToDTO(todoItem);
                    result.ConsultaExitosa();
            }
            catch (Exception ex)
            {
                result = this.GeneraError<TodoItemDto>(ex);
            }

            return result;
        }

        public Result<object> PutTodoItem(long id, TodoItemDto todoItemDto)
        {
            Result<object> result = new Result<object>();
            try
            {
                if (id != todoItemDto.Id)
                    throw new BadRequestException("La peticion no es valida", "Identificador no coincide con el id del parametro");

                var todoItem = this.repository.GetTodoItem(id);

                if (todoItem == null)
                    throw new NotFoundException("No se encontro el registro", "No se encontro el registro con el id" + id);

                todoItem.Name = todoItemDto.Name;
                todoItem.IsComplete = todoItemDto.IsComplete;

                this.repository.Update(todoItem);

                result.ActualizacionExitosa();
            }
            catch (Exception ex)
            {

                result = this.GeneraError<object>(ex);
            }

            return result;
        }

        public Result<TodoItemDto> PostTodoItem(TodoItemDto todoItemDto) 
        {
            Result<TodoItemDto> result = new Result<TodoItemDto>();
            try
            {
                var todoItem = DtoToEntity(todoItemDto);
                this.repository.Insert(todoItem);
                todoItemDto.Id = todoItem.Id;
                
                result.Resultado =  todoItemDto;
                result.CreacionExitosa();
            }
            catch (Exception ex)
            {
                result = this.GeneraError<TodoItemDto>(ex);
            }

            return result;
        }

        public Result<object> DeleteTodoItem(long id) 
        {
            Result<object> result = new Result<object>();
            try
            {
                var todoItem = this.repository.GetTodoItem(id);
                if (todoItem == null)
                    throw new Exception("El registro no se encontro");

                this.repository.Delete(todoItem);

                result.EliminacionExitosa();

            }
            catch (Exception ex)
            {

                result = this.GeneraError<object>(ex);
            }

            return result;
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
