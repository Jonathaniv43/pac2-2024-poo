using AutoMapper;
using BlogUNAH.API.Database.Entities;
using BlogUNAH.API.Dtos.Categories;

namespace BlogUNAH.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>(); // mapea los valores que coinciden entre donde se envia a donde se recibe
            CreateMap<CategoryCreateDto, CategoryEntity>();
            CreateMap<CategoryEditDto, CategoryEntity>();
        }
    }
}
