using CourseSelling.Catalog.Api.Repositories;
using CourseSelling.Shared;
using MassTransit;
using MediatR;
using MongoDB.Driver.Linq;
using System.Net;

namespace CourseSelling.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context)
        : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>>
            Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var existCategory = await context.Categories.
                AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (existCategory)
                ServiceResult<CreateCategoryResponse>.Error
                    ("Category name already exists",
                    $"The Category '{request.Name}' already exists.",
                    HttpStatusCode.BadRequest);

            var category = new Category
            {
                Id = NewId.NextGuid(),
                Name = request.Name
            };

            await context.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(
                new CreateCategoryResponse(category.Id),
                $"<empty>");
        }
    }
}
