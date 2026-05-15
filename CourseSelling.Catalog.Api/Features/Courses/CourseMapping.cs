using CourseSelling.Catalog.Api.Features.Courses.Create;

namespace CourseSelling.Catalog.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>().ReverseMap();
        }
    }
}