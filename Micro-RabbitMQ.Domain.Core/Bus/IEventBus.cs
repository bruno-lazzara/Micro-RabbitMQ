using Micro_RabbitMQ.Domain.Core.Commands;
using Micro_RabbitMQ.Domain.Core.Events;

namespace Micro_RabbitMQ.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;
        void Publish<T>(T eventToPublish) where T : Event;
        void Subscribe<T, THandler>() where T : Event where THandler : IEventHandler<T>;
    }
}
