using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Services;
using Domain.Shared.Extensions;
using Domain.Requested.Models;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class CreateProspectHandler : IHandler<CreateProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IPictureStorage _pictureStorage;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public CreateProspectHandler(IProspectRepository prospectRepository, IPictureStorage pictureStorage, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _prospectRepository = prospectRepository;
                _pictureStorage = pictureStorage;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(CreateProspectCommand request, CancellationToken cancellationToken) {
                    try {
                        var prospect = new Prospect(
                            name: request.Name,
                            goal: request.Goal,
                            contact: request.Contact,
                            biography: request.Biography,
                            status: request.Status,
                            birth: request.Birth,
                            picture:
                                await request.Picture.Store(_pictureStorage)
                        );

                            await _prospectRepository.Create(prospect);
                            await _unityOfWork.Commit();

                                return _commandResult.Created();
                    } catch (Exception) {
                        _unityOfWork.Rollback();

                            return _commandResult.InternalServerError();
                    }
                }
        }
    }