using CourseSelling.Catalog.Api.Options;
using MongoDB.Driver;

namespace CourseSelling.Catalog.Api.Repositories
{
    public static class RepositoryExt
    {
        public static IServiceCollection AddDatabaseServiceExt(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(x =>
            {
                var options = x.GetRequiredService<MongoOption>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddScoped(x =>
            {
                var mongoClient = x.GetRequiredService<IMongoClient>();
                var options = x.GetRequiredService<MongoOption>();

                return AppDbContext.Create(mongoClient.GetDatabase(options.DatabaseName));
            });

            return services;
        }
    }
}
