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
        private readonly IUsersRepository _usersRepository;
        public OrdersController(IOrdersRepository repository, IMapper mapper, IUsersRepository usersRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _usersRepository = usersRepository;
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

        [HttpPost("{id}")]
        public IActionResult CreateOrder(int id, [FromBody] OrderToCreateDto orderToCreate)
        {

            if (orderToCreate == null)
                return BadRequest();

            if(_repository.OrderExists(id)) 
                return BadRequest("order already exist");

            var orderDetail = orderToCreate.OrderDetails.ToList();
            var newOrderDetails = _mapper.Map<List<OrderDetail>>(orderDetail);

            var newOrder = _mapper.Map<Order>(orderToCreate);
            
            _repository.AddOrder(newOrder, newOrderDetails);
            _repository.SaveChanges();

            return Created("GetOrder", orderToCreate);
        }

        //[HttpPut("{idOrder}")]
        //[Authorize]
        //public IActionResult UpdateOrder(int idOrder, [FromBody] OrderToUpdateDto orderUpdated)
        //{
        //    string role = User.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "Client";

        //    if (role != "Admin")
        //    {
        //        return Unauthorized("Not authorized to view users.");
        //    }

        //    var order = _repository.GetOrderById(idOrder);
        //    if (order == null)
        //        return NotFound();

        //    _mapper.Map(orderUpdated, order);

        //    var orderDetails = order.OrderDetails.ToList();
        //    var detailUpdated = orderUpdated.OrderDetails.ToList();

        //    _mapper.Map(detailUpdated, orderDetails);

        //    _repository.Update(order, orderDetails);
        //    _repository.SaveChanges();

        //    return NoContent();
        //}

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
