using Micro_RabbitMQ.Banking.Data.Context;
using Micro_RabbitMQ.Banking.Domain.Interfaces;
using Micro_RabbitMQ.Banking.Domain.Models;

namespace Micro_RabbitMQ.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _context;
        public AccountRepository(BankingDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _context.Accounts;
        }
    }
}
