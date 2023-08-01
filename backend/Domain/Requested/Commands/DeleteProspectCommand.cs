using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;

    namespace Domain.Requested.Commands {
        public class DeleteProspectCommand : Command<CommandResult<Unit>> {
            public Guid Id { get; set; }
        }
    }