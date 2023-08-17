using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Results;
using Domain.Shared.Handlers;
using Domain.Shared.Services;
using Domain.Shared.Extensions;
using Domain.Shared.Enumerators;
using Domain.Requested.Commands;
using Domain.Requested.Repositories;

    namespace Domain.Requested.Handlers {
        public class UpdateProspectHandler : IHandler<UpdateProspectCommand> {
            private readonly IProspectRepository _prospectRepository;
            private readonly IPictureStorage _pictureStorage;
            private readonly IUnityOfWork _unityOfWork;
            private readonly ICommandResult<Unit> _commandResult;
            public UpdateProspectHandler(IProspectRepository prospectRepository, IPictureStorage pictureStorage, IUnityOfWork unityOfWork, ICommandResult<Unit> commandResult) {
                _prospectRepository = prospectRepository;
                _pictureStorage = pictureStorage;
                _unityOfWork = unityOfWork;
                _commandResult = commandResult;
            }

                public async Task<ICommandResult<Unit>> Handle(UpdateProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            try {
                                if(prospect.Dates.Count(date => date.Status == EStatus.Requested) > 0) {
                                    return _commandResult.BadRequest();
                                } else {
                                    prospect.Update(
                                        name: request.Name,
                                        goal: request.Goal,
                                        contact: request.Contact,
                                        biography: request.Biography,
                                        status: request.Status,
                                        birth: request.Birth,
                                        picture:
                                            await request.Picture.Store(_pictureStorage)
                                    );

                                        _prospectRepository.Update(prospect);

                                            await _unityOfWork.Commit();

                                                return _commandResult.OK();
                                }
                            } catch (Exception) {
                                _unityOfWork.Rollback();

                                    return _commandResult.InternalServerError();
                            }
                        }

                            return _commandResult.NotFound();
                }
        }
    }