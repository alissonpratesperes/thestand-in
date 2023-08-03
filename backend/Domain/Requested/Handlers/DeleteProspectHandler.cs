using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class DeleteProspectHandler : Handler<DeleteProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IUnityOfWork _unityOfWork;
            public DeleteProspectHandler(IProspectRepository prospectRepository, IUnityOfWork unityOfWork) {
                _prospectRepository = prospectRepository;
                _unityOfWork = unityOfWork;
            }

                public override async Task<CommandResult<Unit>> Handle(DeleteProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            try {
                                _prospectRepository.Delete(prospect);

                                    await _unityOfWork.Commit();

                                        return new CommandResult<Unit>(
                                            statusCode: HttpStatusCode.NoContent,
                                            statusHint: "NoContent"
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