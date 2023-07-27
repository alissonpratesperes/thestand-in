using MediatR;

using Domain.Shared.Commands;

    namespace Domain.Requested.Commands {
        public class DeleteProspectCommand : Command<Unit> {
            public Guid Id { get; set; }
        }
    }