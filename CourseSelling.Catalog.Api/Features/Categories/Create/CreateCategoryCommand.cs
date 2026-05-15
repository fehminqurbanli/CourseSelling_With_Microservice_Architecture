using static CourseSelling.Shared.ServiceResult;

namespace CourseSelling.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name) : IRequestByServiceResult<CreateCategoryResponse>;
}
