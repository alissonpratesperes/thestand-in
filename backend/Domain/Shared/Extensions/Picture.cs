using Domain.Shared.Services;

    namespace Domain.Shared.Extensions {
        public static class Picture {
            public static async Task<string?> Store(this string? base64, IPictureStorage service) {
                return base64 != null ? base64.StartsWith("data:") ? await service.Store(base64) : base64 : base64;
            }
        }
    }