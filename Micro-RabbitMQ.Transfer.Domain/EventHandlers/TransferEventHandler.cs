using Micro_RabbitMQ.Domain.Core.Bus;
using Micro_RabbitMQ.Transfer.Domain.Events;
using Micro_RabbitMQ.Transfer.Domain.Interfaces;
using Micro_RabbitMQ.Transfer.Domain.Models;

namespace Micro_RabbitMQ.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public TransferEventHandler()
        {
        }

        public Task Handle(TransferCreatedEvent eventToHandle)
        {
            var transferLog = new TransferLog()
            {
                FromAccount = eventToHandle.From,
                ToAccount = eventToHandle.To,
                Amount = eventToHandle.Amount
            };

            _transferRepository.Add(transferLog);

            return Task.CompletedTask;
        }
    }
}
