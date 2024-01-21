using Micro_RabbitMQ.Domain.Core.Bus;
using Micro_RabbitMQ.Transfer.Application.Interfaces;
using Micro_RabbitMQ.Transfer.Domain.Interfaces;
using Micro_RabbitMQ.Transfer.Domain.Models;

namespace Micro_RabbitMQ.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IEventBus _eventBus;
        public TransferService(ITransferRepository transferRepository, IEventBus eventBus)
        {
            _transferRepository = transferRepository;
            _eventBus = eventBus;
        }


        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }
    }
}
