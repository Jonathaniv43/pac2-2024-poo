using BlogUNAH.API.Database.Entities;
using BlogUNAH.API.Dtos.Categories;
using BlogUNAH.API.Dtos.Common;
using BlogUNAH.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace BlogUNAH.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private List<CategoryEntity> _categories;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            // Eliminamos
            //    _categories = new List<Category>
            //    {
            //        new Category { Id = Guid.Parse("b8822aaf-b34c-4c06-bb9c-d56a6e784f01"), Name ="Javascript", Description ="El lenguaje mas facil del mundo" },
            //        new Category { Id = Guid.Parse("6e517a89-71e3-4404-aa9b-346af4698c7e"), Name ="IA", Description ="Tecnologia de moda 2024" },
            //        new Category { Id = Guid.Parse("43efe324-1a6c-44fa-b876-f9900809257c"), Name ="Node.JS", Description ="Entrono de ejecuccion de JavaScriot" }
            //    };
            this._categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CategoryDto>>>> GetAll()
        {
            var response = await _categoriesService.GetCategoriesListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<CategoryDto>>> Get(Guid id)
        {
            //var category = await _categoriesService.GetCategoryByIdAsync(id);
            //if (category == null)
            //{
            //    return NotFound(new { Message = $"No se encontró la categoría: {id}" });
            //}
            //return Ok(category);
            var response  = await _categoriesService.GetCategoryByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<CategoryDto>>> Create(CategoryCreateDto dto)
        {
            //bool categoryExist = _categories.Any(x => x.
            //Name.ToUpper().Trim().Contains(category.Name.ToUpper()));

            //if (!categoryExist)
            //{
            //    return BadRequest("La categoria ya esta registrada");
            //}

            //category.Id = Guid.NewGuid();

            //_categories.Add(category);
            /////if (category.Name.Equals("") { }
            ///VALIDACION DENTRO DEL CONTROLLER
            //if (string.IsNullOrEmpty(category.Name)) 
            //{
            //    return BadRequest(new { Message = "El nombre de la categoria es requerido" });
            //}
            //if(!string.IsNullOrEmpty(category.Description) && category.Description.Length < 10)
            //{
            //    return BadRequest(new {Message = "La descripción debe tener al menos 10 catacteres"});
            //}
            var response = await _categoriesService.CreateAsync(dto);



            return StatusCode(response.StatusCode, response);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<CategoryDto>>> Edit(CategoryEditDto dto, Guid id)
        {
            var response = await _categoriesService.EditAsync(dto, id);
            //if (!result)
            //{
            //    return NotFound();
            //}
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<CategoryDto>>> Delete(Guid id)
        {
            //var response = await _categoriesService.GetCategoryByIdAsync(id);

            //if (category  is null)
            //{
            //    return NotFound();
            //}

            var response = await _categoriesService.DeleteAsync(id);
            return StatusCode(response.StatusCode,response);
        }
    }
}