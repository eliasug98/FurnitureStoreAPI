using AutoMapper;
using FurnitureStore.API.DTOs.OrderDTOs;
using FurnitureStore.API.DTOs.ProductCategoryDTOs;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FurnitureStore.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _repository;
        private readonly IMapper _mapper;
        public OrdersController(IOrdersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Order>> GetAll()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to view users.");
            }

            List<Order> orders = _repository.GetAllOrders().ToList();
            if (orders.Count == 0)
                return NotFound("The order list is empty");

            //var orderDto = _mapper.Map<List<OrderDto>>(orders);
            return Ok(orders);
        }


        [HttpGet("{idOrder}", Name = "GetOrder")]
        [Authorize]
        public IActionResult GetOrder(int idOrder)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to view orders.");
            }

            if (!_repository.OrderExists(idOrder))
                return NotFound();

            Entities.Order? order = _repository.GetOrderById(idOrder);
            var orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public IActionResult GetOrdersByUserId(int userId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to view orders.");
            }

            //if (!_repository.OrderExists(idOrder))
            //    return NotFound();

            List<Order> orders = _repository.GetOrdersByUserId(userId).ToList();

            if (orders.Count == 0) 
                return NotFound("Order list is empty");

            var orderDto = _mapper.Map<OrderDto>(orders);

            return Ok(orderDto);
        }

        [HttpPost("{id}")]
        public IActionResult CreateOrder(int id, [FromBody] OrderToCreateDto orderToCreate)
        {
            if (orderToCreate == null)
                return BadRequest();

            if (_repository.OrderExists(id))
                return BadRequest("order already exist");

            var orderDetail = orderToCreate.OrderDetails.ToList();
            var newOrderDetails = _mapper.Map<List<OrderDetail>>(orderDetail);

            var newOrder = _mapper.Map<Order>(orderToCreate);

            _repository.AddOrder(newOrder, newOrderDetails);

            return Created("Created", orderToCreate);
        }


        [HttpDelete("{idOrder}")]
        [Authorize]
        public IActionResult DeleteOrder(int idOrder)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

            if (role != "Admin")
            {
                return Unauthorized("Not authorized to delete orders.");
            }

            if (!_repository.OrderExists(idOrder))
                return NotFound();

            var orderToDelete = _repository.DeleteOrderAndDetails(idOrder);

            if(orderToDelete == false)
                return NotFound();

            _repository.SaveChanges();

            return NoContent();
        }

    }
}
