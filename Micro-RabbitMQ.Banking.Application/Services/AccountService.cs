using Micro_RabbitMQ.Banking.Application.Interfaces;
using Micro_RabbitMQ.Banking.Domain.Interfaces;
using Micro_RabbitMQ.Banking.Domain.Models;

namespace Micro_RabbitMQ.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
