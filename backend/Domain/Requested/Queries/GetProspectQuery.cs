using Domain.Shared.Returns;
using Domain.Shared.Queries;
using Domain.Requested.ViewModels;

    namespace Domain.Requested.Queries {
        public class GetProspectQuery : IQuery<Return<GetProspectViewModel>> {
            public Guid Id { get; set; }
        }
    }