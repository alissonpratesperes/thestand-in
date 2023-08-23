using Domain.Shared.Returns;
using Domain.Shared.Queries;
using Domain.Shared.Paginations;
using Domain.Requester.ViewModels;

    namespace Domain.Requester.Queries {
        public class ListDateQuery : IQuery<Return<Pagination<ListDateViewModel>>> {
            public int Page { get; set; } = 1;
            public int Length { get; set; } = 1;
            public int? Status { get; set; } = 0;
        }
    }