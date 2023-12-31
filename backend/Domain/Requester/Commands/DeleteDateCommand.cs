using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;

    namespace Domain.Requester.Commands {
        public class DeleteDateCommand : ICommand<ICommandResult<Unit>> {
            public Guid Id { get; set; }
        }
    }