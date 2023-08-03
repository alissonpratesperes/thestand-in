using MediatR;
using System.Net;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Requester.Commands;
using Domain.Requester.Repositories;

    namespace Domain.Requester.Handlers {
        public class UpdateDateHandler : Handler<UpdateDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            public UpdateDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
            }

                public override async Task<CommandResult<Unit>> Handle(UpdateDateCommand request, CancellationToken cancellationToken) {
                    var date = await _dateRepository.Read(request.Id);

                        if(date != null) {
                            try {
                                date.Update(
                                    name: request.Name,
                                    title: request.Title,
                                    status: request.Status,
                                    contact: request.Contact,
                                    schedule: request.Schedule,
                                    latitude: request.Latitude,
                                    longitude: request.Longitude,
                                    description: request.Description,
                                    displacement: request.Displacement,
                                    contribution: request.Contribution,
                                    prospectId: request.ProspectId
                                );

                                    _dateRepository.Update(date);

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