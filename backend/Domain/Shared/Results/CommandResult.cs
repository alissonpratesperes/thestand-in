using System.Net;

    namespace Domain.Shared.Results {
        public class CommandResult<T> {
            public HttpStatusCode StatusCode { get; set; }
            public string StatusHint { get; set; }

                public CommandResult(
                    HttpStatusCode statusCode,
                    string statusHint
                ) {
                    this.StatusCode = statusCode;
                    this.StatusHint = statusHint;
                }
        }
    }