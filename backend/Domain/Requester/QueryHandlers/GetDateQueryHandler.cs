using Domain.Shared.Returns;
using Domain.Shared.QueryHandlers;
using Domain.Requester.Queries;
using Domain.Requester.ViewModels;
using Domain.Requester.QueryRepositories;

    namespace Domain.Requester.QueryHandlers {
        public class GetDateQueryHandler : IQueryHandler<GetDateQuery, Return<GetDateViewModel>> {
            private readonly IDateQueryRepository _dateQueryRepository;
            public GetDateQueryHandler(IDateQueryRepository dateQueryRepository) {
                _dateQueryRepository = dateQueryRepository;
            }

                public async Task<Return<GetDateViewModel>> Handle(GetDateQuery query, CancellationToken cancellationToken) {
                    var date = await _dateQueryRepository.Get(query.Id);

                        return date != null
                            ?  Return<GetDateViewModel>.Succeeded(date)
                            :  Return<GetDateViewModel>.Failure(date);
                }
        }
    }