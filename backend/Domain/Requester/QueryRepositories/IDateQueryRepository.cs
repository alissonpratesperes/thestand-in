using Domain.Requester.ViewModels;

    namespace Domain.Requester.QueryRepositories {
        public interface IDateQueryRepository {
            Task<IEnumerable<ListDateViewModel>> List(int page, int length);
            Task<int> Count();
            Task<GetDateViewModel> Get(Guid id);
        }
    }