using MediatR;
using Micro_RabbitMQ.Banking.Domain.Commands;
using Micro_RabbitMQ.Banking.Domain.Events;
using Micro_RabbitMQ.Domain.Core.Bus;

namespace Micro_RabbitMQ.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _eventBus;
        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            _eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
