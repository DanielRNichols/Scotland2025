using ErrorOr;
using MediatR;

namespace Scotland2025.Application.Abstractions.Queries;
public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : IErrorOr
{
}
