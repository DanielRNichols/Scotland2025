using ErrorOr;
using MediatR;

namespace Scotland2025.Application.Abstractions.Commands;
public interface ICommand<TResponse> : IRequest<TResponse> where TResponse : IErrorOr
{
}
