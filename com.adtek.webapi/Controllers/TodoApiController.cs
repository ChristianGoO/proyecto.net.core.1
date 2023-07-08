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
    public class TodoApiController : MainController
    {
        private readonly TodoItemService  service;

        public TodoApiController(TodoItemService service)
        {
            this.service = service;
        }

        // GET: api/TodoApi
        [HttpGet]
        [ProducesResponseType(typeof(ApiResults<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TodoItemDto>>> GetTodoItems()
        {
            return await this.RespuestaAsync(this.service.GetTodoItems());
        }

        // GET: api/TodoApi/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResults<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TodoItemDto>> GetTodoItem(long id)
        {
            return await this.RespuestaAsync(this.service.GetTodoItem(id));
        }

        // PUT: api/TodoApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResults<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutTodoItem(long id, TodoItemDto todoItemDto)
        {
            return await this.RespuestaAsync(this.service.PutTodoItem(id, todoItemDto));
        
        }

        // POST: api/TodoApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<TodoItemDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TodoItemDto>> PostTodoItem(TodoItemDto todoItemDto)
        {
            return await this.RespuestaAsync(this.service.PostTodoItem(todoItemDto));
        }

        // DELETE: api/TodoApi/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResults<TodoItemDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResult<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            return await this.RespuestaAsync(this.service.DeleteTodoItem(id));
        }
    }
}
