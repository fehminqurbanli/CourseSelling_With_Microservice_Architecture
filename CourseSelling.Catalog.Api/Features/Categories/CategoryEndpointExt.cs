using CourseSelling.Catalog.Api.Features.Categories.Create;
using CourseSelling.Catalog.Api.Features.Categories.GetAll;
using CourseSelling.Catalog.Api.Features.Categories.GetById;

namespace CourseSelling.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app) 
        {
            app.MapGroup("api/categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllGroupItemEndpoint()
                .GetCategoryByIdGroupItemEndpoint();
        }
    }
}
