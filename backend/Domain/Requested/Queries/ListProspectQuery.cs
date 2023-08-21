using Domain.Shared.Queries;
using Domain.Shared.Returns;
using Domain.Shared.Paginations;
using Domain.Requested.ViewModels;

    namespace Domain.Requested.Queries {
        public class ListProspectQuery : IQuery<Return<Pagination<ListProspectViewModel>>> {
            public int Page { get; set; } = 1;
            public int Length { get; set; } = 1;
        }
    }