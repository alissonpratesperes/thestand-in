using MediatR;

using Domain.Shared.Results;
using Domain.Shared.Commands;
using Domain.Shared.Enumerators;

    namespace Domain.Requester.Commands {
        public class CreateDateCommand : ICommand<CommandResult<Unit>> {
            public string Name { get; set; }
            public string Title { get; set; }
            public EStatus Status { get; set; }
            public string Contact { get; set; }
            public DateTime Schedule { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string Description { get; set; }
            public EDisplacement Displacement { get; set; }
            public decimal Contribution { get; set; }
            public Guid ProspectId { get; set; }
        }
    }