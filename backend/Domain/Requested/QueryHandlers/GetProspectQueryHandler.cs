using Microsoft.Extensions.Caching.Memory;

using Domain.Shared.Returns;
using Domain.Shared.QueryHandlers;
using Domain.Requested.Queries;
using Domain.Requested.ViewModels;
using Domain.Requested.QueryRepositories;

    namespace Domain.Requested.QueryHandlers {
        public class GetProspectQueryHandler : IQueryHandler<GetProspectQuery, Return<GetProspectViewModel>> {
            private readonly IProspectQueryRepository _prospectQueryRepository;
            private readonly IMemoryCache _memoryCache;
            public GetProspectQueryHandler(IProspectQueryRepository prospectQueryRepository, IMemoryCache memoryCache) {
                _prospectQueryRepository = prospectQueryRepository;
                _memoryCache = memoryCache;
            }

                public async Task<Return<GetProspectViewModel>> Handle(GetProspectQuery query, CancellationToken cancellationToken) {
                    var cachedResult = await _memoryCache.GetOrCreate("GetOfProspect", async entry => {
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                            var prospect = await _prospectQueryRepository.Get(query.Id);

                                return prospect != null
                                    ?  Return<GetProspectViewModel>.Succeeded(prospect)
                                    :  Return<GetProspectViewModel>.Failure(prospect);
                    });

                        return cachedResult;
                }
        }
    }