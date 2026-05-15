using CourseSelling.Catalog.Api.Features.Categories.DTOs;

namespace CourseSelling.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequestByServiceResult<CategoryDTO>;
    

    public class GetCategoryByIdQueryHandler(AppDbContext dbContext, IMapper mapper) : 
        IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDTO>>
    {
        public async Task<ServiceResult<CategoryDTO>> 
            Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await dbContext.Categories.FindAsync(request.Id, cancellationToken);

            if (category == null)
            {
                return ServiceResult<CategoryDTO>.
                    Error("Category not found.",
                          $"The category with Id({request.Id}) was not found",
                          HttpStatusCode.NotFound);
            }
            var categoryDTO = mapper.Map<CategoryDTO>(category);
            return ServiceResult<CategoryDTO>.SuccessAsOk(categoryDTO);
        }
    }

    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetCategoryByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetCategoryByIdQuery(id));
                return result.ToGenericResult();
            });
            return group;
        }
    }
}
