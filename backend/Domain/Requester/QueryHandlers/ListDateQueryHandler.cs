using Domain.Shared.Returns;
using Domain.Shared.Paginations;
using Domain.Shared.QueryHandlers;
using Domain.Requester.Queries;
using Domain.Requester.ViewModels;
using Domain.Requester.QueryRepositories;

    namespace Domain.Requester.QueryHandlers {
        public class ListDateQueryHandler : IQueryHandler<ListDateQuery, Return<Pagination<ListDateViewModel>>> {
            private readonly IDateQueryRepository _dateQueryRepository;
            public ListDateQueryHandler(IDateQueryRepository dateQueryRepository) {
                _dateQueryRepository = dateQueryRepository;
            }

                public async Task<Return<Pagination<ListDateViewModel>>> Handle(ListDateQuery query, CancellationToken cancellationToken) {
                    var results = await _dateQueryRepository.List(query.Page, query.Length, query.Status);
                    var count = await _dateQueryRepository.Count(query.Status);
                    var pagination = new Pagination<ListDateViewModel>(
                        count: count,
                        page: query.Page,
                        length: query.Length,
                        results: results
                    );

                        return pagination.Results != null && pagination.Count > 0
                            ?  Return<Pagination<ListDateViewModel>>.Succeeded(pagination)
                            :  Return<Pagination<ListDateViewModel>>.Failure(pagination);
                }
        }
    }