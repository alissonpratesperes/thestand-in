using Domain.Requested.ViewModels;

    namespace Domain.Requested.QueryRepositories {
        public interface IProspectQueryRepository {
            Task<IEnumerable<ListProspectViewModel>> List(int page, int length);
            Task<int> Count();
        }
    }