using CQRS_MEDIATOR_CRUD.Data;
using CQRS_MEDIATOR_CRUD.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS_MEDIATOR_CRUD.Queries
{
    public class GetTodo
    {
        public class Query : IRequest<IEnumerable<Todo>> { }
        public class QueryHandler : IRequestHandler<Query, IEnumerable<Todo>>
        {
            private readonly TodoDbContext _todoDbContext;
            public QueryHandler(TodoDbContext todoDbContext)
            {
                _todoDbContext = todoDbContext;
            }
            public async Task<IEnumerable<Todo>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _todoDbContext.Todo.ToListAsync(cancellationToken);
            }

        }
    }
}

