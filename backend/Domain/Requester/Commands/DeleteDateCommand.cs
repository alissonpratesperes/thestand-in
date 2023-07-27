using MediatR;

using Domain.Shared.Commands;

    namespace Domain.Requester.Commands {
        public class DeleteDateCommand : Command<Unit> {
            public Guid Id { get; set; }
        }
    }