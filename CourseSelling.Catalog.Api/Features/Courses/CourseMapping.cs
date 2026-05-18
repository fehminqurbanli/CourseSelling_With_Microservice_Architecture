using CourseSelling.Catalog.Api.Features.Courses.Create;
using CourseSelling.Catalog.Api.Features.Courses.DTOs;

namespace CourseSelling.Catalog.Api.Features.Courses
{
    public class CourseMapping : Profile
    {
        public CourseMapping()
        {
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<Course, CourseDTO>();
            CreateMap<Feature, FeatureDTO>();

        }
    }
}