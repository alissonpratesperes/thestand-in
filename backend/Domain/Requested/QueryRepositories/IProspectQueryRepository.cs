using Domain.Requested.ViewModels;

    namespace Domain.Requested.QueryRepositories {
        public interface IProspectQueryRepository {
            Task<IEnumerable<ListProspectViewModel>> List(int page, int length, string? search);
            Task<int> Count(string? search);
            Task<GetProspectViewModel> Get(Guid id);
        }
    }