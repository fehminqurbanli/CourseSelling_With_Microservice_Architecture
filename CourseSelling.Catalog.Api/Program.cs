using CourseSelling.Catalog.Api;
using CourseSelling.Catalog.Api.Features.Categories;
using CourseSelling.Catalog.Api.Options;
using CourseSelling.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOptionsExt();

builder.Services.Configure<MongoOption>(
    builder.Configuration.GetSection("MongoOptions"));
builder.Services.AddDatabaseServiceExt(builder.Configuration);

builder.Services.AddCommonServiceExt(typeof(CatalogAssmebly));

var app = builder.Build();

app.AddCategoryGroupEndpointExt();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();