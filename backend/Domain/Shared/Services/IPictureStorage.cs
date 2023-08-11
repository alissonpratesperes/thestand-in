namespace Domain.Shared.Services {
    public interface IPictureStorage {
        Task<string> Store(string? base64);
    }
}