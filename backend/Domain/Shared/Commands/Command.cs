using MediatR;

    namespace Domain.Shared.Commands {
        public abstract class Command<T> : IRequest<T> {

        }
    }