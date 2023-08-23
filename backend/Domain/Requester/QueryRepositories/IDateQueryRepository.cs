using Domain.Requester.ViewModels;

    namespace Domain.Requester.QueryRepositories {
        public interface IDateQueryRepository {
            Task<IEnumerable<ListDateViewModel>> List(int page, int length, int? status);
            Task<int> Count(int? status);
            Task<GetDateViewModel> Get(Guid id);
        }
    }