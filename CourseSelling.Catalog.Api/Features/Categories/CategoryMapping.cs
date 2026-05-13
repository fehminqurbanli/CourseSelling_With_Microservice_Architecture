using AutoMapper;
using CourseSelling.Catalog.Api.Features.Categories.DTOs;

namespace CourseSelling.Catalog.Api.Features.Categories
{
    public class CategoryMapping: Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category,CategoryDTO>().ReverseMap();
        }
    }
}
