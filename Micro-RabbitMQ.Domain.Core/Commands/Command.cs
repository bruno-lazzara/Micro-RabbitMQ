using Micro_RabbitMQ.Domain.Core.Events;

namespace Micro_RabbitMQ.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; protected set; }
    }
}
