using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class UpdateProspectHandler : Handler<UpdateProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IUnityOfWork _unityOfWork;
            public UpdateProspectHandler(IProspectRepository prospectRepository, IUnityOfWork unityOfWork) {
                _prospectRepository = prospectRepository;
                _unityOfWork = unityOfWork;
            }

                public override async Task<CommandResult<Unit>> Handle(UpdateProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            try {
                                prospect.Update(
                                    name: request.Name,
                                    goal: request.Goal,
                                    active: request.Active,
                                    contact: request.Contact,
                                    biography: request.Biography,
                                    available: request.Available,
                                    birth: request.Birth,
                                    picture: request.Picture
                                );

                                    _prospectRepository.Update(prospect);

                                        await _unityOfWork.Commit();

                                            return new CommandResult<Unit>(
                                                statusCode: HttpStatusCode.OK,
                                                statusHint: "OK"
                                            );
                            } catch (Exception exception) {
                                _unityOfWork.Rollback();

                                    return new CommandResult<Unit>(
                                        statusCode: HttpStatusCode.InternalServerError,
                                        statusHint: "InternalServerError"
                                    );
                            }
                        }

                            return new CommandResult<Unit>(
                                statusCode: HttpStatusCode.NotFound,
                                statusHint: "NotFound"
                            );
                }
        }
    }