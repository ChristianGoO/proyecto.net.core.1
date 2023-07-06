using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using com.adtek.br.Services;
using com.adtek.br.Dtos;

namespace com.adtek.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        private readonly TodoItemService  service;

        public TodoApiController(TodoItemService service)
        {
            this.service = service;
        }

        // GET: api/TodoApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            var todoItemsDtos = this.service.GetTodoItems();
            return this.StatusCode(280, todoItemsDtos);
        }

        // GET: api/TodoApi/5
        [HttpGet("producto/{id}")]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(long id)
        {
            return this.service.GetTodoItem(id);
        }

        // PUT: api/TodoApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDto todoItemDto)
        {
            this.service.PutTodoItem(id, todoItemDto);
            return NoContent();
        }

        // POST: api/TodoApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemDto todoItemDto)
        {
            this.service.PostTodoItem(todoItemDto);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItemDto.Id }, todoItemDto);

        }

        // DELETE: api/TodoApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            this.service.DeleteTodoItem(id);
            return NoContent();
        }
    }
}
