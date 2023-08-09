using System.Net;

    namespace Domain.Shared.Results {
        public interface ICommandResult<T> {
            HttpStatusCode StatusCode { get; }
            string StatusHint { get; }

                ICommandResult<T> OK();
                ICommandResult<T> Created();
                ICommandResult<T> NoContent();
                ICommandResult<T> BadRequest();
                ICommandResult<T> NotFound();
                ICommandResult<T> InternalServerError();
        }
    }