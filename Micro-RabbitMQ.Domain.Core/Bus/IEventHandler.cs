using Micro_RabbitMQ.Domain.Core.Events;

namespace Micro_RabbitMQ.Domain.Core.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent eventToHandle);
    }

    public interface IEventHandler
    {

    }
}
