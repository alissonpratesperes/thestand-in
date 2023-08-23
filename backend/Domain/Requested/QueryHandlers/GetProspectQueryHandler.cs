using Domain.Shared.Returns;
using Domain.Shared.QueryHandlers;
using Domain.Requested.Queries;
using Domain.Requested.ViewModels;
using Domain.Requested.QueryRepositories;

    namespace Domain.Requested.QueryHandlers {
        public class GetProspectQueryHandler : IQueryHandler<GetProspectQuery, Return<GetProspectViewModel>> {
            private readonly IProspectQueryRepository _prospectQueryRepository;
            public GetProspectQueryHandler(IProspectQueryRepository prospectQueryRepository) {
                _prospectQueryRepository = prospectQueryRepository;
            }

                public async Task<Return<GetProspectViewModel>> Handle(GetProspectQuery query, CancellationToken cancellationToken) {
                    var prospect = await _prospectQueryRepository.Get(query.Id);

                        return prospect != null
                            ?  Return<GetProspectViewModel>.Succeeded(prospect)
                            :  Return<GetProspectViewModel>.Failure(prospect);
                }
        }
    }