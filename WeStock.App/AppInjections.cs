using WeStock.Domain.Repositories;
using WeStock.Domain.Services;

namespace WeStock.App
{
    public class AppInjections
    {
        public static void Register(IServiceCollection services)
        {
            RegisterServices(services);
            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
        }
    }
}
