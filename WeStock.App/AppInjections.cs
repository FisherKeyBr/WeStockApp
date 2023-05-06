using Microsoft.EntityFrameworkCore;
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
            RegisterServices(services);
            RegisterRepositories(services);
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
