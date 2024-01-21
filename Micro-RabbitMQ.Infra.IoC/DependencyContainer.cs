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

            #region Domain Banking Commands

            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            #endregion

            #region Application Services

            services.AddTransient<IAccountService, AccountService>();

            #endregion

            #region Data

            services.AddTransient<BankingDbContext>();

            services.AddTransient<IAccountRepository, AccountRepository>();

            #endregion
        }
    }
}
