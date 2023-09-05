using Microsoft.Extensions.Caching.Memory;

using Domain.Shared.Returns;
using Domain.Shared.QueryHandlers;
using Domain.Requester.Queries;
using Domain.Requester.ViewModels;
using Domain.Requester.QueryRepositories;

    namespace Domain.Requester.QueryHandlers {
        public class GetDateQueryHandler : IQueryHandler<GetDateQuery, Return<GetDateViewModel>> {
            private readonly IDateQueryRepository _dateQueryRepository;
            private readonly IMemoryCache _memoryCache;
            public GetDateQueryHandler(IDateQueryRepository dateQueryRepository, IMemoryCache memoryCache) {
                _dateQueryRepository = dateQueryRepository;
                _memoryCache = memoryCache;
            }

                public async Task<Return<GetDateViewModel>> Handle(GetDateQuery query, CancellationToken cancellationToken) {
                    var cachedKey = $"GetDate_{query.Id}";
                    var cachedResult = await _memoryCache.GetOrCreate(cachedKey, async entry => {
                        entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

                            var date = await _dateQueryRepository.Get(query.Id);

                                return date != null
                                    ?  Return<GetDateViewModel>.Succeeded(date)
                                    :  Return<GetDateViewModel>.Failure(date);
                    });

                        return cachedResult;
                }
        }
    }