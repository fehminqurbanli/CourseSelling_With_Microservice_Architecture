using CourseSelling.Shared;
using MediatR;

namespace CourseSelling.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name):IRequest<ServiceResult<CreateCategoryResponse>>;
}
