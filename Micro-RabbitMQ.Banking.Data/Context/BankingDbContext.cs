using Micro_RabbitMQ.Banking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro_RabbitMQ.Banking.Data.Context
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext()
        {
        }

        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=BankingDB;User ID=sa;Password=aPcnD18125/;MultipleActiveResultSets=True;Persist Security Info=True;Encrypt=False");
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
