using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Enumerators;
using Domain.Requester.Commands;
using Domain.Requester.Repositories;

    namespace Domain.Requester.Handlers {
        public class DeleteDateHandler : Handler<DeleteDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            public DeleteDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
            }

                public override async Task<CommandResult<Unit>> Handle(DeleteDateCommand request, CancellationToken cancellationToken) {
                    var date = await _dateRepository.Read(request.Id);

                        if(date != null) {
                            try {
                                if(date.Status != EStatus.Requested) {
                                    return new CommandResult<Unit>(
                                        statusCode: HttpStatusCode.BadRequest,
                                        statusHint: "BadRequest"
                                    );
                                } else {
                                    _dateRepository.Delete(date);

                                        await _unityOfWork.Commit();

                                            return new CommandResult<Unit>(
                                                statusCode: HttpStatusCode.NoContent,
                                                statusHint: "NoContent"
                                            );
                                }
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