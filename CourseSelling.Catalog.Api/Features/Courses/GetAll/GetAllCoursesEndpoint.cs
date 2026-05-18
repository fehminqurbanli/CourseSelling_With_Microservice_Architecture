using CourseSelling.Catalog.Api.Features.Courses.DTOs;

namespace CourseSelling.Catalog.Api.Features.Courses.GetAll
{
    public class GetAllCoursesQuery: IRequestByServiceResult<List<CourseDTO>>;

    public class GetAllCoursesQueryHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDTO>>>
    {
        public async Task<ServiceResult<List<CourseDTO>>> Handle(GetAllCoursesQuery request,
            CancellationToken cancellationToken)
        {
            var courses = await context.Courses
                .ToListAsync(cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken);


            foreach (var course in courses) course.Category = categories.First(x => x.Id == course.CategoryId);

            var coursesAsDto = mapper.Map<List<CourseDTO>>(courses);
            return ServiceResult<List<CourseDTO>>.SuccessAsOk(coursesAsDto);
        }
    }

    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                    async (IMediator mediator) =>
                        (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                .WithName("GetAllCourses");

            return group;
        }
    }
}
