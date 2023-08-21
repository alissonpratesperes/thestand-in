using MediatR;

    namespace Domain.Shared.QueryHandlers {
        public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult> {
            Task<TResult> Handle(TQuery query, CancellationToken cancellationToken);
        }
    }