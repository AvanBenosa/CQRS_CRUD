using CQRS_MEDIATOR_CRUD.Data;
using CQRS_MEDIATOR_CRUD.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MEDIATOR_CRUD.Queries
{
    public class GetTodoById
    {
        public class Query : IRequest<Todo>
        {
            public int Id { get; set; }
        }
         
        public class QueryHandler : IRequestHandler<Query,Todo>
        {
            private readonly TodoDbContext _todoDbContext;
            public QueryHandler(TodoDbContext todoDbContext)
            {
                _todoDbContext = todoDbContext;
            }
            public async Task<Todo> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _todoDbContext.Todo.FindAsync(request.Id);
            }
        }
    }
}
