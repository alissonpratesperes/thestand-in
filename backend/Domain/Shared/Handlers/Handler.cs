using MediatR;

    namespace Domain.Shared.Handlers {
        public abstract class Handler<T> : IRequestHandler<T, Unit> where T : IRequest<Unit> {
            public abstract Task<Unit> Handle(T request, CancellationToken cancellationToken);
        }
    }