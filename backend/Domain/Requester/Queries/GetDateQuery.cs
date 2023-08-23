using Domain.Shared.Returns;
using Domain.Shared.Queries;
using Domain.Requester.ViewModels;

    namespace Domain.Requester.Queries {
        public class GetDateQuery : IQuery<Return<GetDateViewModel>> {
            public Guid Id { get; set; }
        }
    }