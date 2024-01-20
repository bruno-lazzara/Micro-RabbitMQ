using Micro_RabbitMQ.Domain.Core.Bus;
using Micro_RabbitMQ.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Micro_RabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Domain Bus

            services.AddTransient<IEventBus, RabbitMQBus>();

            #endregion
        }
    }
}
