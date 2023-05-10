using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeStock.Domain;
using WeStock.Domain.ExternalApis;
using WeStock.Domain.Services;
using WeStock.Infra;
using WeStock.Infra.ExternalApis;

namespace WeStock.Bot
{
    public class BotInjections
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            RegisterServices(serviceCollection);
            RegisterRepositories(serviceCollection);
            RegisterRabbitMQ(serviceCollection);
        }

        private static void RegisterRabbitMQ(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPublishMessageHandler>(x =>
            {
                var factory = new ConnectionFactory { HostName = MessageBrokerConstants.HOST };
                var connection = factory.CreateConnection();

                return new PublishMessageHandler(connection);
            });

            serviceCollection.AddScoped<BotQueueEventHandlers>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IStockMarketApi, AlphaVantageApi>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ChatBotService>();
        }
    }
}
