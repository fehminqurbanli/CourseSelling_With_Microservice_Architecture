using CourseSelling.Catalog.Api.Features.Categories;
using CourseSelling.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;

namespace CourseSelling.Catalog.Api.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        public static AppDbContext Create(IMongoDatabase mongoDatabase)
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseMongoDB(mongoDatabase.Client,
                    mongoDatabase.DatabaseNamespace.DatabaseName);

            return new AppDbContext(optionBuilder.Options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
