using CourseSelling.Catalog.Api.Features.Categories.DTOs;

namespace CourseSelling.Catalog.Api.Features.Courses.DTOs
{
    public record CourseDTO(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string ImageUrl,
        DateTime Created,
        CategoryDTO Category,
        FeatureDTO Feature);
}
