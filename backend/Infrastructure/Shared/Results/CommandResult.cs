using System.Net;

using Domain.Shared.Results;

    namespace Infrastructure.Shared.Results {
        public class CommandResult<T> : ICommandResult<T> {
            public HttpStatusCode StatusCode { get; private set; }
            public string StatusHint { get; private set; }

                public CommandResult(HttpStatusCode statusCode = HttpStatusCode.Accepted, string statusHint = "Accepted") {
                    this.StatusCode = statusCode;
                    this.StatusHint = statusHint;
                }

                    public ICommandResult<T> OK() {
                        this.StatusCode = HttpStatusCode.OK;
                        this.StatusHint = "OK";

                            return this;
                    }
                    public ICommandResult<T> Created() {
                        this.StatusCode = HttpStatusCode.Created;
                        this.StatusHint = "Created";

                            return this;
                    }
                    public ICommandResult<T> NoContent() {
                        this.StatusCode = HttpStatusCode.NoContent;
                        this.StatusHint = "NoContent";

                            return this;
                    }
                    public ICommandResult<T> BadRequest() {
                        this.StatusCode = HttpStatusCode.BadRequest;
                        this.StatusHint = "BadRequest";

                            return this;
                    }
                    public ICommandResult<T> NotFound() {
                        this.StatusCode = HttpStatusCode.NotFound;
                        this.StatusHint = "NotFound";

                            return this;
                    }
                    public ICommandResult<T> InternalServerError() {
                        this.StatusCode = HttpStatusCode.InternalServerError;
                        this.StatusHint = "InternalServerError";

                            return this;
                    }
        }
    }