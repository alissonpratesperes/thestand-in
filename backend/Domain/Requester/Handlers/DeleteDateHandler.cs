using MediatR;

using Domain.Shared.Data;
using Domain.Shared.Handlers;
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

                public override async Task<Unit> Handle(DeleteDateCommand request, CancellationToken cancellationToken) {
                    var date = await _dateRepository.Read(request.Id);

                        if(date != null) {
                            _dateRepository.Delete(date);

                                await _unityOfWork.Commit();

                                    return Unit.Value;
                        }

                            return Unit.Value;
                }
        }
    }