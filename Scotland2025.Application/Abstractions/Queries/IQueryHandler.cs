using ErrorOr;
using MediatR;

namespace Scotland2025.Application.Abstractions.Queries;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : IErrorOr
{
}
