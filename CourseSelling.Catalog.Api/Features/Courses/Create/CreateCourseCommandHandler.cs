namespace CourseSelling.Catalog.Api.Features.Courses.Create
{
    public class CreateCourseCommandHandler(AppDbContext context, IMapper mapper)
        : IRequestHandler<CreateCourseCommand, ServiceResult<Guid>>
    {
        public async Task<ServiceResult<Guid>> 
            Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.AnyAsync(c => c.Id == request.CategoryId, cancellationToken);

            if (!hasCategory)
                return ServiceResult<Guid>.Error("Category not Found", 
                    $"Category with id ({request.CategoryId}) not found.",
                    HttpStatusCode.NotFound);

            var hasCourse = await context.Courses.AnyAsync(c => c.Name == request.Name, cancellationToken);

            if (hasCourse)
                return ServiceResult<Guid>.Error("Course already exists.",
                    $"Course with name ({request.Name}) already exists.",
                    HttpStatusCode.BadRequest);

            var newCourse = mapper.Map<Course>(request);
            newCourse.Id = NewId.NextSequentialGuid(); //index performance
            newCourse.Created = DateTime.Now;
            newCourse.Feature = new Feature()
            {
                Duration = 10,  //calculate
                EducatorFullName = "Fahmin Gurbanli", //from token
                Rating = 0
            };

            await context.AddAsync(newCourse, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);


            return ServiceResult<Guid>.SuccessAsCreated(newCourse.Id, $"/api/courses/{newCourse.Id}");
        }
    }
}
