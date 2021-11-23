using CQRS_MEDIATOR_CRUD.Data;
using CQRS_MEDIATOR_CRUD.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MEDIATOR_CRUD.Command
{
    public class PostTodo
    {
        public class Command : IRequest<Todo>
        {
            public string TaskName { get; set; }
            public int Deadline { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Todo>
        {
            private readonly TodoDbContext _todoDbContext;
            public CommandHandler(TodoDbContext todoDbContext)
            {
                _todoDbContext = todoDbContext;
            }
            public async Task<Todo> Handle(Command command, CancellationToken cancellationToken)
            {
                var entity = new Todo
                {
                    TaskName = command.TaskName,
                    Deadline = command.Deadline
                };
                await _todoDbContext.Todo.AddAsync(entity, cancellationToken);
                await _todoDbContext.SaveChangesAsync(cancellationToken);

                return entity;
            }
        }

    }
}
