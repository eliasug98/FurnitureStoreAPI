using AutoMapper;
using FurnitureStore.API.DTOs.ProductDTOs;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FurnitureStore.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetProducts()
        {
            List<Product>? products = _repository.GetProducts().ToList();
            if(products.Count == 0)
                return NotFound("The product list is empty");

            var productsDto = _mapper.Map<List<ProductDto>>(products);
            return Ok(productsDto);
        }

        [HttpGet("{idProduct}", Name = "GetProduct")]
        public IActionResult GetProduct(int idProduct)
        {
            Entities.Product? product = _repository.GetProductById(idProduct);

            if(product == null)
            {
                return NotFound("can´t find product");
            }

            ProductDto productDto = _mapper.Map<ProductDto>(product); 

            return Ok(productDto);
        }


        [HttpPost]
        [Authorize]
        public ActionResult<ProductDto> CreateProduct([FromBody] ProductToCreateDto productToCreate)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to create products.");
            }

            if (productToCreate == null)
                return NotFound();

            if(_repository.ProductExists(productToCreate.Name))
                return BadRequest();
                
            var newProduct = _mapper.Map<Product>(productToCreate);

            _repository.AddProduct(newProduct);

            var saved = _repository.SaveChanges();
            if (saved != true)
            {
                return BadRequest("product could not be created");
            }

            return Created("Created", _mapper.Map<ProductDto>(newProduct)); //
        }

        [HttpPut("{idProduct}")]
        [Authorize]
        public ActionResult UpdateProduct(int idProduct, [FromBody] ProductToUpdateDto productUpdated)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to update products.");
            }

            var productToUpdate = _repository.GetProductById(idProduct);
            if (productToUpdate == null)
                return NotFound();

            _mapper.Map(productUpdated, productToUpdate);

            _repository.Update(productToUpdate);

            var saved = _repository.SaveChanges();
            if (saved != true)
            {
                return BadRequest("product could not be updated");
            }

            return NoContent();
        }

        [HttpPut("stock/{id}")]
        [Authorize]
        public ActionResult UpdateStock(int id)
        {

            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to update products.");
            }

            var productToUpdate = _repository.GetProductById(id);
            if (productToUpdate == null)
                return NotFound();

            productToUpdate.Available = !productToUpdate.Available;

            _repository.Update(productToUpdate);

            if (!_repository.SaveChanges())
            {
                return BadRequest("product could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{idProduct}")]
        [Authorize]
        public ActionResult DeleteProduct(int idProduct)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to delete products.");
            }

            var productToDelete = _repository.GetProductById(idProduct);
            if (productToDelete == null) 
                return NotFound();

            _repository.DeleteProduct(productToDelete);

            var saved = _repository.SaveChanges();
            if(saved != true)
            {
                return BadRequest("product could not be deleted");
            }

            return NoContent();
        }

    }
}
