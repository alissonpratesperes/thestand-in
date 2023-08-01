using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;

    namespace Domain.Requester.Commands {
        public class DeleteDateCommand : Command<CommandResult<Unit>> {
            public Guid Id { get; set; }
        }
    }