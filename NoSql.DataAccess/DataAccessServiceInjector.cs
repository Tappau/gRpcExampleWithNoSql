using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NoSql.Core.Domain;

namespace NoSql.DataAccess
{
    public static class DataAccessServiceInjector
    {
        /// <summary>
        /// Add mongo connection settings
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services
          , IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDB"));
            services.AddSingleton<IMongoDbSettings>(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            return services;
        }

        /// <summary>
        /// Add all mongo DataAccess repositories.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMongoRepositories(this IServiceCollection services)
        {
            services.AddTransient<IMongoBaseRepository<Person>, MongoBaseRepository<Person>>();
            return services;
        }
    }
}