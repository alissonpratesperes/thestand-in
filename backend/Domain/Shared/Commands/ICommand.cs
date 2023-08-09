using MediatR;

using Domain.Shared.Results;

    namespace Domain.Shared.Commands {
        public interface ICommand<T> : IRequest<ICommandResult<Unit>> {

        }
    }