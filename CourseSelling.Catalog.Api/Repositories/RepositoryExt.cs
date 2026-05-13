using CourseSelling.Catalog.Api.Options;
using CourseSelling.Catalog.Api.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public static class RepositoryExt
{
    public static IServiceCollection AddDatabaseServiceExt(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<IMongoClient>(x =>
        {
            var options = x
                .GetRequiredService<IOptions<MongoOption>>()
                .Value;

            return new MongoClient(options.ConnectionString);
        });

        services.AddScoped(x =>
        {
            var mongoClient = x.GetRequiredService<IMongoClient>();

            var options = x
                .GetRequiredService<IOptions<MongoOption>>()
                .Value;

            return AppDbContext.Create(
                mongoClient.GetDatabase(options.DatabaseName));
        });

        return services;
    }
}