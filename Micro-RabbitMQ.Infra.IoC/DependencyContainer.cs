using MediatR;
using Micro_RabbitMQ.Banking.Application.Interfaces;
using Micro_RabbitMQ.Banking.Application.Services;
using Micro_RabbitMQ.Banking.Data.Context;
using Micro_RabbitMQ.Banking.Data.Repository;
using Micro_RabbitMQ.Banking.Domain.CommandHandlers;
using Micro_RabbitMQ.Banking.Domain.Commands;
using Micro_RabbitMQ.Banking.Domain.Interfaces;
using Micro_RabbitMQ.Domain.Core.Bus;
using Micro_RabbitMQ.Infra.Bus;
using Micro_RabbitMQ.Transfer.Application.Interfaces;
using Micro_RabbitMQ.Transfer.Application.Services;
using Micro_RabbitMQ.Transfer.Data.Context;
using Micro_RabbitMQ.Transfer.Data.Repository;
using Micro_RabbitMQ.Transfer.Domain.EventHandlers;
using Micro_RabbitMQ.Transfer.Domain.Events;
using Micro_RabbitMQ.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Micro_RabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //TODO possible refactor - create one Dependency Container class inside each project that uses it, so each project registers only the services it needs.
            //e.g. the Transfer API does not need to register BankingDbContext, AccountService, AccountRepository etc.

            #region Domain Bus

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            #endregion

            #region Subscriptions

            services.AddTransient<TransferEventHandler>();

            #endregion

            #region Domain Events

            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            #endregion

            #region Domain Banking Commands

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            #endregion

            #region Application Services

            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            #endregion

            #region Data

            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            #endregion
        }
    }
}
