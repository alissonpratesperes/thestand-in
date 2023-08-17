using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;

    namespace Domain.Requester.Actions.Commands {
        public class AcceptDateCommand : ICommand<ICommandResult<Unit>> {
            public Guid Id { get; set; }
            public Guid ProspectId { get; set; }
        }
    }