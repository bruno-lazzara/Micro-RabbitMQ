using Micro_RabbitMQ.Transfer.Data.Context;
using Micro_RabbitMQ.Transfer.Domain.Interfaces;
using Micro_RabbitMQ.Transfer.Domain.Models;

namespace Micro_RabbitMQ.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _context;
        public TransferRepository(TransferDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _context.TransferLogs;
        }

        public void Add(TransferLog transferLog)
        {
            _context.TransferLogs.Add(transferLog);
            _context.SaveChanges();
        }
    }
}
