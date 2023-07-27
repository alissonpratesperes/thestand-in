using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Handlers;
using Domain.Requester.Models;
using Domain.Requester.Commands;
using Domain.Requester.Repositories;

    namespace Domain.Requester.Handlers {
        public class CreateDateHandler : Handler<CreateDateCommand> {
            private readonly IDateRepository _dateRepository;
            private readonly IUnityOfWork _unityOfWork;
            public CreateDateHandler(IDateRepository dateRepository, IUnityOfWork unityOfWork) {
                _dateRepository = dateRepository;
                _unityOfWork = unityOfWork;
            }

                public override async Task<Unit> Handle(CreateDateCommand request, CancellationToken cancellationToken) {
                    var date = new Date(
                        name: request.Name,
                        title: request.Title,
                        status: request.Status,
                        contact: request.Contact,
                        schedule: request.Schedule,
                        latitude: request.Latitude,
                        longitude: request.Longitude,
                        description: request.Description,
                        displacement: request.Displacement,
                        contribution: request.Contribution
                    );

                        await _dateRepository.Create(date);
                        await _unityOfWork.Commit();

                            return Unit.Value;
                }
        }
    }