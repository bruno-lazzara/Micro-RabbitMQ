using Micro_RabbitMQ.Banking.Domain.Models;

namespace Micro_RabbitMQ.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
