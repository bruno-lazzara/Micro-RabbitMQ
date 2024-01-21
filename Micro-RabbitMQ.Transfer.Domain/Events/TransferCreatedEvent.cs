using Micro_RabbitMQ.Domain.Core.Events;

namespace Micro_RabbitMQ.Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public TransferCreatedEvent(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }

        public int From { get; private set; }
        public int To { get; private set; }
        public decimal Amount { get; private set; }

        //TODO possible refactor - create a class library with all the events in one place, since this event is exactly the same as Micro_RabbitMQ.Banking.Domain.Events.TransferCreatedEvent
    }
}
