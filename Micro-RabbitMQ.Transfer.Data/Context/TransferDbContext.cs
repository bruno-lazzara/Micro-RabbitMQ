using Micro_RabbitMQ.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro_RabbitMQ.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext()
        {
        }

        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=TransferDB;User ID=sa;Password=aPcnD18125/;MultipleActiveResultSets=True;Persist Security Info=True;Encrypt=False");
        }

        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
