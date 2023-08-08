using MediatR;

using Domain.Shared.Results;

    namespace Domain.Shared.Handlers {
        public interface IHandler<T> : IRequestHandler<T, CommandResult<Unit>> where T : IRequest<CommandResult<Unit>> {
            Task<CommandResult<Unit>> Handle(T request, CancellationToken cancellationToken);
        }
    }