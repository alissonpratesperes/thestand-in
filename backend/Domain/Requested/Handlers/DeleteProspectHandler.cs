using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class DeleteProspectHandler : IHandler<DeleteProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IUnityOfWork _unityOfWork;
            public DeleteProspectHandler(IProspectRepository prospectRepository, IUnityOfWork unityOfWork) {
                _prospectRepository = prospectRepository;
                _unityOfWork = unityOfWork;
            }

                public async Task<CommandResult<Unit>> Handle(DeleteProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            try {
                                if(prospect.Dates.Count > 0) {
                                    return new CommandResult<Unit>(
                                        statusCode: HttpStatusCode.BadRequest,
                                        statusHint: "BadRequest"
                                    );
                                } else {
                                    _prospectRepository.Delete(prospect);

                                        await _unityOfWork.Commit();

                                            return new CommandResult<Unit>(
                                                statusCode: HttpStatusCode.NoContent,
                                                statusHint: "NoContent"
                                            );
                                }
                            } catch (Exception) {
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