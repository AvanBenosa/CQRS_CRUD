using CQRS_MEDIATOR_CRUD.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MEDIATOR_CRUD.Command
{
    public class DeleteTodo
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly TodoDbContext _todoDbContext;
            public CommandHandler(TodoDbContext todoDbContext)
            {
                _todoDbContext = todoDbContext;
            }
            public async Task<Unit> Handle(Command command, CancellationToken cancellationToken)
            {
                var todo = await _todoDbContext.Todo.FindAsync(command.Id);
                if (todo == null) return Unit.Value;

                _todoDbContext.Todo.Remove(todo);
                await _todoDbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
