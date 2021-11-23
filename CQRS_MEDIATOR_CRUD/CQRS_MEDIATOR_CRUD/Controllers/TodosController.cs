using CQRS_MEDIATOR_CRUD.Command;
using CQRS_MEDIATOR_CRUD.Model;
using CQRS_MEDIATOR_CRUD.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CQRS_MEDIATOR_CRUD.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IEnumerable<Todo>> GetTodo()
        {
            return await _mediator.Send(new GetTodo.Query());
        }

        [HttpGet("/{id}")]
        public async Task<Todo> GetTodoById(int id)
        {
            return await _mediator.Send(new GetTodoById.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> PostTodo([FromBody] PostTodo.Command command)
        {
            var createdTodoId = await _mediator.Send(command);
            return Created("", createdTodoId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodo command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            await _mediator.Send(new DeleteTodo.Command { Id = id });
            return NoContent();
        }

    }
}
