using BlogUNAH.API.Dtos.Categories;
using BlogUNAH.API.Dtos.Common;
using System.Reflection.Metadata.Ecma335;

namespace BlogUNAH.API.Services.Interfaces
{
    public interface ICategoriesService
    {
        // Similar a una clse pero no es lo mismo (interfaz no permite crear logica{define un contrato})

       
        Task<ResponseDto<List<CategoryDto>>> GetCategoriesListAsync();
        
        Task <ResponseDto<CategoryDto>> GetCategoryByIdAsync(Guid id);  
        
        Task <ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto dto);
        Task<ResponseDto<CategoryDto>> EditAsync(CategoryEditDto dto, Guid id);
        Task<ResponseDto<CategoryDto>> DeleteAsync (Guid id);
    }
}
