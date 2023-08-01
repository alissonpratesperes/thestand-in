using MediatR;

using Domain.Shared.Results;

    namespace Domain.Shared.Commands {
        public abstract class Command<T> : IRequest<CommandResult<Unit>> {

        }
    }