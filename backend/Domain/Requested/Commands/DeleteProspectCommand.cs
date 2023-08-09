using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;

    namespace Domain.Requested.Commands {
        public class DeleteProspectCommand : ICommand<ICommandResult<Unit>> {
            public Guid Id { get; set; }
        }
    }