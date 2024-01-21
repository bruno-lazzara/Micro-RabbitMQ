using Micro_RabbitMQ.Transfer.Domain.Models;

namespace Micro_RabbitMQ.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}
