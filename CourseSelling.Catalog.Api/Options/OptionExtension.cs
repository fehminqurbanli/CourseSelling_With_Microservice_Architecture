using Microsoft.Extensions.Options;

namespace CourseSelling.Catalog.Api.Options
{
    public static class OptionExtension
    {
        public static IServiceCollection AddOptionsExt
            (this IServiceCollection services)
        {
            services.AddOptions<MongoOption>()
                .BindConfiguration(nameof(MongoOption))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddSingleton(x => x.GetRequiredService<IOptions<MongoOption>>().Value);

            return services;
        }
    }
}
