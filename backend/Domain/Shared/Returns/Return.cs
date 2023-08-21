using System.Net;

    namespace Domain.Shared.Returns {
        public class Return<T> {
            public HttpStatusCode StatusCode { get; set; }
            public string StatusHint { get; set; }
            public T Data { get; set; }

                public Return(T data = default, HttpStatusCode statusCode = HttpStatusCode.Accepted, string statusHint = "Accepted") {
                    this.Data = data;
                    this.StatusCode = statusCode;
                    this.StatusHint = statusHint;
                }

                    public static Return<T> Succeeded(T data) {
                        return new Return<T> {
                            StatusCode = HttpStatusCode.OK,
                            StatusHint = "OK",
                            Data = data
                        };
                    }
                    public static Return<T> Failure(T data) {
                        return new Return<T> {
                            StatusCode = HttpStatusCode.NoContent,
                            StatusHint = "NoContent",
                            Data = data
                        };
                    }
        }
    }