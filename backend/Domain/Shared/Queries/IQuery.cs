using MediatR;

    namespace Domain.Shared.Queries {
        public interface IQuery<T> : IRequest<T> {

        }
    }