using AutoMapper;
using FurnitureStore.API.DTOs.ProductCategoryDTOs;
using FurnitureStore.API.DTOs.ProductDTOs;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FurnitureStore.API.Controllers
{
    [ApiController]
    [Route("api/productCategory")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoriesRepository _repository;
        private readonly IMapper _mapper;

        public ProductCategoriesController(IProductCategoriesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ProductCategoryDto>> GetCategories()
        {
            List<ProductCategory> productCategories = _repository.GetAllCategories().ToList();
            if (productCategories.Count == 0)
                return NotFound("The product list is empty");

            var productCategoryDto = _mapper.Map<List<ProductCategoryDto>>(productCategories);
            return Ok(productCategoryDto);
        }

        [HttpGet("{idCategory}")]
        public IActionResult GetCategoryById(int idCategory)
        {
            ProductCategory? category = _repository.GetCategoryById(idCategory);
            if (category == null)
                return NotFound();

            return Ok(_mapper.Map<ProductCategoryDto>(category));
        }


        [HttpPut]
        [Authorize]
        public IActionResult UpdateCategoryName([FromBody] ProductCategoryToUpdateDto categoryUpdated)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to update category.");
            }

            ProductCategory? category = _repository.GetCategoryByName(categoryUpdated.CurrentName);
            if(category == null)
                return NotFound();

            category.Name = categoryUpdated.NewName;
            category.Description = categoryUpdated.Description;
            // Si Icon está vacío, toma el icono existente
            if (string.IsNullOrWhiteSpace(categoryUpdated.Icon))
            {
                category.Icon = category.Icon;  // Mantiene el icono existente
            }
            else
            {
                category.Icon = categoryUpdated.Icon;  // Actualiza con el nuevo icono
            }

            _repository.Update(category);

            _repository.SaveChanges();

            return NoContent();

        }

        [HttpPost]
        [Authorize]
        public ActionResult<ProductCategoryDto> CreateCategory([FromBody] ProductCategoryToCreateDto productCategoryToCreate)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to create categories.");
            }

            if (productCategoryToCreate == null)
                return NotFound();

            if (_repository.ProductCategoryExists(productCategoryToCreate.Name))
                return BadRequest();

            var newProductCategory = _mapper.Map<ProductCategory>(productCategoryToCreate);

            _repository.AddProductCategory(newProductCategory);

            var saved = _repository.SaveChanges();
            if (saved != true)
            {
                return BadRequest("productCategory could not be created");
            }

            return Created("Created", _mapper.Map<ProductCategoryDto>(newProductCategory)); // ver
        }
    }
}
