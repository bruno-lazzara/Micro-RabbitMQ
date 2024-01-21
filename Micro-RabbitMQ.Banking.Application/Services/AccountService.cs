using Micro_RabbitMQ.Banking.Application.Interfaces;
using Micro_RabbitMQ.Banking.Application.Models;
using Micro_RabbitMQ.Banking.Domain.Commands;
using Micro_RabbitMQ.Banking.Domain.Interfaces;
using Micro_RabbitMQ.Banking.Domain.Models;
using Micro_RabbitMQ.Domain.Core.Bus;

namespace Micro_RabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _eventBus;
        public AccountService(IAccountRepository accountRepository, IEventBus eventBus)
        {
            _accountRepository = accountRepository;
            _eventBus = eventBus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.TransferAmount);

            _eventBus.SendCommand(createTransferCommand);
        }
    }
}
