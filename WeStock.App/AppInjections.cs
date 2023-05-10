using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Text;
using WeStock.App.Dtos;
using WeStock.App.Validators;
using WeStock.Domain;
using WeStock.Domain.Entities;
using WeStock.Domain.ExternalApis;
using WeStock.Domain.Repositories;
using WeStock.Domain.Services;
using WeStock.Infra;
using WeStock.Infra.ExternalApis;
using WeStock.Infra.Repositories;

namespace WeStock.App
{
    public class AppInjections
    {
        public static void Register(IServiceCollection services)
        {
            RegisterDbContext(services);
            RegisterValidators(services);
            RegisterServices(services);
            RegisterRepositories(services);

            RegisterRabbitMQ(services);
        }

        private static void RegisterRabbitMQ(IServiceCollection services)
        {   
            services.AddScoped<IPublishMessageHandler>(x =>
            {
                var factory = new ConnectionFactory { HostName = MessageBrokerConstants.HOST };
                var connection = factory.CreateConnection();
                
                return new PublishMessageHandler(connection);
            });

            services.AddScoped<AppQueueEventHandlers>();
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<LoginDto>, LoginValidator>();
            services.AddScoped<IValidator<SendMessageDto>, SendMessageValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();
        }

        private static void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<EntityContext>(opt => opt.UseInMemoryDatabase(EntityContext.DB_NAME));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IStockMarketApi, AlphaVantageApi>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<MessageService>();
            services.AddScoped<ChatBotService>();
        }
    }
}
