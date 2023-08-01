using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Requested.Models;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class CreateProspectHandler : Handler<CreateProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IUnityOfWork _unityOfWork;
            public CreateProspectHandler(IProspectRepository prospectRepository, IUnityOfWork unityOfWork) {
                _prospectRepository = prospectRepository;
                _unityOfWork = unityOfWork;
            }

                public override async Task<CommandResult<Unit>> Handle(CreateProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = new Prospect(
                        name: request.Name,
                        goal: request.Goal,
                        active: request.Active,
                        contact: request.Contact,
                        biography: request.Biography,
                        available: request.Available,
                        birth: request.Birth,
                        picture: request.Picture
                    );

                        await _prospectRepository.Create(prospect);
                        await _unityOfWork.Commit();

                            return new CommandResult<Unit>(
                                statusCode: HttpStatusCode.Created,
                                statusHint: "Created"
                            );
                }
        }
    }