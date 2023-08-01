using MediatR;

using Domain.Shared.Results;

    namespace Domain.Shared.Handlers {
        public abstract class Handler<T> : IRequestHandler<T, CommandResult<Unit>> where T : IRequest<CommandResult<Unit>> {
            public abstract Task<CommandResult<Unit>> Handle(T request, CancellationToken cancellationToken);
        }
    }