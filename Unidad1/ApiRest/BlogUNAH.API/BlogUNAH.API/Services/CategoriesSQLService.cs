using AutoMapper;
using BlogUNAH.API.Database;
using BlogUNAH.API.Database.Entities;
using BlogUNAH.API.Dtos.Categories;
using BlogUNAH.API.Dtos.Common;
using BlogUNAH.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BlogUNAH.API.Services
{
    public class CategoriesSQLService : ICategoriesService

    {
        private readonly BlogUNAHContext _context;
        private readonly IMapper _mapper;
         
        public CategoriesSQLService(BlogUNAHContext context, IMapper mapper) // Injectar contexto de base de datos
        {
            this._context = context; // mapea la base de datos 
            this._mapper = mapper;
        }
        public async Task<ResponseDto<List<CategoryDto>>> GetCategoriesListAsync()
        {
            var categoriesEntity = await _context.Categories.ToListAsync();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categoriesEntity); // origen de datos cateEnt
            
            // Eliminamos Mappeando estos campos desde el orige al destino y regresandolo en este caso como lista
            //var categoriesDtos = categoriesEntity.Select(e => new CategoryDto {
            //    // con ayuda del automapper enviaremos c
            //    Id = e.Id,
            //    Name = e.Name,
            //    Description = e.Description,


            //}).ToList();
            return new ResponseDto<List<CategoryDto>>
            {
                StatusCode = 200,
                Status = true,
                Message= "Lista de Registros obtenida correctamnete",
                Data = categoriesDtos
            };

        }

        public async Task<ResponseDto<CategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryEntity == null) 
            {
                return new ResponseDto<CategoryDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = " No se encontro el registro"

                };
            }

            var categoryDto= _mapper.Map<CategoryDto>(categoryEntity);// Fuente de datos CategoryEntity y se encia un category Dto 
            //var categoryDto = new CategoryDto // debemos injectar 
            //{
            //    Id = id,
            //    Name = categroryEntity.Name,
            //    Description = categroryEntity.Description,
            //};
            return new ResponseDto<CategoryDto> 
            { 
                StatusCode = 200,
                Status = true,
                Message = "Registro Encontrado",
                Data = categoryDto
            
            };
        }
        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryCreateDto dto)
        {

            var categoryEntity = _mapper.Map<CategoryEntity>(dto);
            // To Do : Validar que la categoria no se repita
            _context.Categories.Add(categoryEntity);
            // Guardar cambios
            await _context.SaveChangesAsync();
            
            // mapeamos cuando posee el category entity el id para poder obtenerlo una vez creado
            // Pues al crear no existe debe generarse
            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);

            return new ResponseDto<CategoryDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Registro creado correctamnete",
                Data = categoryDto,
            };

        }
        public async Task<ResponseDto<CategoryDto>> EditAsync(CategoryEditDto dto, Guid id)
        {
            // Valida si existe
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (categoryEntity == null)
            {
                return new ResponseDto<CategoryDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = " No se encontro el registro"

                };
            }
            _mapper.Map<CategoryEditDto, CategoryEntity>(dto, categoryEntity);
            _context.Categories.Update(categoryEntity);
            await _context.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(categoryEntity);

            return new ResponseDto<CategoryDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro modificado correctamente",
                Data = categoryDto,
            };
        }
        public async Task<ResponseDto<CategoryDto>> DeleteAsync(Guid id)
        {
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (categoryEntity == null)
            {
                return new ResponseDto<CategoryDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = " No se encontro el registro"

                };
            }

            _context.Categories.Remove(categoryEntity);
            await _context.SaveChangesAsync();
            return new ResponseDto<CategoryDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Registro borrado Correctamente"

            };
        }

       
    }
}
