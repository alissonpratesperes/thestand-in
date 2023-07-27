using MediatR;

using Domain.Shared.Data;
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

                public override async Task<Unit> Handle(DeleteProspectCommand request, CancellationToken cancellationToken) {
                    var prospect = await _prospectRepository.Read(request.Id);

                        if(prospect != null) {
                            _prospectRepository.Delete(prospect);

                                await _unityOfWork.Commit();

                                    return Unit.Value;
                        }

                            return Unit.Value;
                }
        }
    }