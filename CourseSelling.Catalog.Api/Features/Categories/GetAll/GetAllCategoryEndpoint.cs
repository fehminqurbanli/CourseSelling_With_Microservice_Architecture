using CourseSelling.Catalog.Api.Features.Categories.DTOs;

namespace CourseSelling.Catalog.Api.Features.Categories.GetAll
{
    public class GetAllCategoryQuery: IRequestByServiceResult<List<CategoryDTO>>;

    public class GetAllCategoryHandler(AppDbContext dbContext, IMapper mapper) : 
        IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDTO>>>
    {
        public async Task<ServiceResult<List<CategoryDTO>>> 
            Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await dbContext.Categories.ToListAsync(cancellationToken);
            var categoryDTOs = mapper.Map<List<CategoryDTO>>(categories);

            return ServiceResult<List<CategoryDTO>>.SuccessAsOk(categoryDTOs);
        }
    }


    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new GetAllCategoryQuery());

                return result.ToGenericResult();
            });

            return group;
        }
    }
}
