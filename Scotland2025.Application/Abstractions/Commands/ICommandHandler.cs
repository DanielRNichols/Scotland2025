using ErrorOr;
using MediatR;

namespace Scotland2025.Application.Abstractions.Commands;
public interface ICommandHandler<TCommand, TResponse>: IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : IErrorOr
{
}
