using CourseSelling.Catalog.Api.Features.Courses.Create;
using CourseSelling.Catalog.Api.Features.Courses.GetAll;
using CourseSelling.Catalog.Api.Features.Courses.GetById;

namespace CourseSelling.Catalog.Api.Features.Courses
{
    public static class CourseEndpointExt
    {
        public static void AddCourseGroupEndpointExt(this WebApplication app)
        {
            app.MapGroup("api/courses")
                .WithTags("Courses")
                .CreateCourseGroupItemEndpoint()
                .GetAllCourseGroupItemEndpoint()
                .GetByIdCourseGroupItemEndpoint();
        }
    }
}
