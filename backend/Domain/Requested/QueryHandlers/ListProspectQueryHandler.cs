using Domain.Shared.Returns;
using Domain.Shared.Paginations;
using Domain.Shared.QueryHandlers;
using Domain.Requested.Queries;
using Domain.Requested.ViewModels;
using Domain.Requested.QueryRepositories;

    namespace Domain.Requested.QueryHandlers {
        public class ListProspectQueryHandler : IQueryHandler<ListProspectQuery, Return<Pagination<ListProspectViewModel>>> {
            private readonly IProspectQueryRepository _prospectQueryRepository;
            public ListProspectQueryHandler(IProspectQueryRepository prospectQueryRepository) {
                _prospectQueryRepository = prospectQueryRepository;
            }

                public async Task<Return<Pagination<ListProspectViewModel>>> Handle(ListProspectQuery query, CancellationToken cancellationToken) {
                    var results = await _prospectQueryRepository.List(query.Page, query.Length, query.Search);
                    var count = await _prospectQueryRepository.Count(query.Search);
                    var pagination = new Pagination<ListProspectViewModel>(
                        count: count,
                        page: query.Page,
                        length: query.Length,
                        results: results
                    );

                        return pagination.Results != null && pagination.Count > 0
                            ?  Return<Pagination<ListProspectViewModel>>.Succeeded(pagination)
                            :  Return<Pagination<ListProspectViewModel>>.Failure(pagination);
                }
        }
    }