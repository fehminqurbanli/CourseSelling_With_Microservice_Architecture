using CourseSelling.Catalog.Api.Features.Courses.DTOs;

namespace CourseSelling.Catalog.Api.Features.Courses.GetById
{
    public record GetCourseByIdQuery(Guid Id) : IRequestByServiceResult<CourseDTO>;

    public class GetCourseByIdQueryHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDTO>>
    {
        public async Task<ServiceResult<CourseDTO>> Handle(GetCourseByIdQuery request,
            CancellationToken cancellationToken)
        {
            var hasCourse = await context.Courses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (hasCourse is null)
                return ServiceResult<CourseDTO>.Error("Course not found",
                    $"The course with id({request.Id}) was not found", HttpStatusCode.NotFound);

            var category = await context.Categories.FindAsync(hasCourse.CategoryId, cancellationToken);

            hasCourse.Category = category!;

            var courseAsDto = mapper.Map<CourseDTO>(hasCourse);
            return ServiceResult<CourseDTO>.SuccessAsOk(courseAsDto);
        }
    }

    public static class GetCourseByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}",
                    async (IMediator mediator, Guid id) =>
                        (await mediator.Send(new GetCourseByIdQuery(id))).ToGenericResult())
                .WithName("GetByIdCourses");

            return group;
        }
    }
}
