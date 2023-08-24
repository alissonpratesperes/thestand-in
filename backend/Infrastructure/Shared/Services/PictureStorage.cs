using MediatR;
using Microsoft.Extensions.Hosting;

using Domain.Shared.Services;

    namespace Infrastructure.Shared.Services {
        public class PictureStorage : IPictureStorage {
            private readonly IHostingEnvironment _hostingEnvironment;
            public PictureStorage(IHostingEnvironment hostingEnvironment) {
                _hostingEnvironment = hostingEnvironment;
            }

                public async Task<string> Store(string? base64) {
                    byte[] picture = Convert.FromBase64String(base64.Split(',')[1]);
                    string name = Guid.NewGuid().ToString() + "." + GetExtension(base64);
                    string path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot/pictures", name);

                        using (var stream = new FileStream(path, FileMode.Create)) {
                            await stream.WriteAsync(picture, 0, picture.Length);
                        }

                            return name;
                }

                    private string GetExtension(string base64) {
                        string[] split = base64.Split(',');
                        string data;

                            data = (split.Length == 2) ? split[1].Substring(0, 5) : split[0].Substring(0, 5);

                                return data.ToUpper() switch {
                                    "IVBOR"  =>  "png",
                                    "/9J/4"  =>  "jpg",

                                        _ => string.Empty
                                };
                    }
        }
    }