namespace Domain.Shared.Data {
    public interface IUnityOfWork {
        Task<int> Commit();
    }
}