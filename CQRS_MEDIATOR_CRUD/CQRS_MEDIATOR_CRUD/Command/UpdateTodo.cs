using CQRS_MEDIATOR_CRUD.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MEDIATOR_CRUD.Command
{
    public class UpdateTodo : IRequest<int>
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int Deadline { get; set; }

        public class CommandHandler : IRequestHandler<UpdateTodo, int>
        {
            private readonly TodoDbContext _todoDbContext;
            public CommandHandler(TodoDbContext todoDbContext)
            {
                _todoDbContext = todoDbContext;
            }
            public async Task<int> Handle(UpdateTodo command, CancellationToken cancellationToken)
            {
                var todo = _todoDbContext.Todo.Where(a => a.Id == command.Id).FirstOrDefault();

                if (todo == null)
                {
                    return default;
                }
                else
                {
                    todo.TaskName = command.TaskName;
                    todo.Deadline = command.Deadline;
                    await _todoDbContext.SaveChangesAsync();
                    return todo.Id;
                }
            }
        }
    }
}
