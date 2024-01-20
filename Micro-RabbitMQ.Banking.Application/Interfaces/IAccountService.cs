using Micro_RabbitMQ.Banking.Domain.Models;

namespace Micro_RabbitMQ.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
