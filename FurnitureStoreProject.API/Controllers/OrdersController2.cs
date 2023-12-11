//using AutoMapper;
//using FurnitureStore.API.DTOs.OrderDTOs;
//using FurnitureStore.API.DTOs.ProductCategoryDTOs;
//using FurnitureStore.API.Entities;
//using FurnitureStore.API.Services.Interfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Security.Claims;
////using MercadoPago.Config;
////using MercadoPago.Resources;
////using MercadoPago.DataStructures.Preference;

//namespace FurnitureStore.API.Controllers
//{
//    [ApiController]
//    [Route("api/orders")]
//    public class OrdersController2 : ControllerBase
//    {
//        private readonly IOrdersRepository _repository;
//        private readonly IMapper _mapper;
//        private readonly IUsersRepository _usersRepository;
//        public OrdersController(IOrdersRepository repository, IMapper mapper, IUsersRepository usersRepository)
//        {
//            _repository = repository;
//            _mapper = mapper;
//            _usersRepository = usersRepository;
//        }

//        [HttpGet]
//        public ActionResult<List<OrderDto>> GetAll()
//        {
//            List<Order> orders = _repository.GetAllOrders().ToList();
//            if (orders.Count == 0)
//                return NotFound("The order list is empty");

//            var orderDto = _mapper.Map<List<OrderDto>>(orders);
//            return Ok(orderDto);
//        }

//        [HttpGet("{idOrder}", Name = "GetOrder")]
//        public IActionResult GetOrder(int idOrder)
//        {
//            if (!_repository.OrderExists(idOrder))
//                return NotFound();

//            Entities.Order? order = _repository.GetOrderById(idOrder);
//            var orderDto = _mapper.Map<OrderDto>(order);

//            return Ok(orderDto);
//        }

//        [HttpPost("{id}")]
//        [Authorize]
//        public ActionResult<OrderDto> CreateOrder(int id, [FromBody] OrderToCreateDto orderCreated)
//        {
//            //var userId = User.FindFirstValue("sub");
//            //var currentUser = _usersRepository.GetCurrentUser(int.Parse(userId));
//            //if (currentUser.Role != "Admin")
//            //    return Unauthorized("dont have authorization to access");

//            if (orderCreated == null)
//                return BadRequest();

//            if (_repository.OrderExists(id))
//                return BadRequest("order already exist");

//            var newOrder = _mapper.Map<Order>(orderCreated);
//            // var newOrderDetail = _mapper.Map<OrderDetail>(orderCreated.OrderDetails); y paso newOrderDetail a AddOrder, y modifico para agregar
//            _repository.AddOrder(newOrder);
//            _repository.SaveChanges();

//            //// Crear la preferencia de pago
//            //Preference preference = CrearPreferencia(newOrder);

//            // Obtener la URL de pago
//            //string urlDePago = preference.InitPoint;

//            return Created("GetOrder", _mapper.Map<OrderDto>(newOrder)); /*, paymentUrl = urlDePago*/
//        }

//        //private void CrearPreferencia(Order order)
//        //{
//        //    // Configurar las credenciales
//        //    MercadoPagoConfig.AccessToken = "TU-ACCESS-TOKEN";

//        //    // Crear el objeto de request de la preferencia
//        //    Preference preference = new Preference();

//        //    // Crear una lista de detalles de orden
//        //    List<Item> items = new List<Item>();
//        //    foreach (var detail in order.OrderDetails)
//        //    {
//        //        items.Add(new Item
//        //        {
//        //            Title = detail.ProductName, // falta esta propiedad
//        //            Quantity = detail.Quantity,
//        //            UnitPrice = detail.Price
//        //        });
//        //    }

//        //    preference.Items = items;

//        //    // Guardar la preferencia
//        //    preference.Save();
//        //}



//        [HttpPut("{idOrder}")]
//        [Authorize]
//        public ActionResult UpdateOrder(int idOrder, [FromBody] OrderToUpdateDto orderUpdated)
//        {
//            //var userId = User.FindFirstValue("sub");
//            //var currentUser = _usersRepository.GetCurrentUser(int.Parse(userId));
//            //if (currentUser.Role != "Admin")
//            //    return Unauthorized("dont have authorization to access");

//            var order = _repository.GetOrderById(idOrder);
//            if (order == null)
//                return NotFound();

//            _mapper.Map(orderUpdated, order);

//            // Actualizar la relacion OrderDetails
//            var orderDetails = order.OrderDetails.ToList();
//            var detailUpdated = orderUpdated.OrderDetails.ToList();

//            _mapper.Map(detailUpdated, orderDetails); // DEBERIA ESTAR???
//            _repository.Update(order, orderDetails); //DEBERIA ESTAR????? EL OD.
//            //// _context.OrderDetails.UpdateRange(order.OrderDetails);
//            //// _context.Orders.Update(order);

//            _repository.SaveChanges();

//            return NoContent();
//        }

//        [HttpDelete("{idOrder}")]
//        [Authorize]
//        public ActionResult DeleteOrder(int idOrder)
//        {
//            //var userId = User.FindFirstValue("sub");
//            //var currentUser = _usersRepository.GetCurrentUser(int.Parse(userId));
//            //if (currentUser.Role != "Admin")
//            //    return Unauthorized("dont have authorization to access");

//            if (!_repository.OrderExists(idOrder))
//                return NotFound();

//            var orderToDelete = _repository.DeleteOrderAndDetails(idOrder);

//            if (orderToDelete == false)
//                return NotFound();

//            _repository.SaveChanges();

//            return NoContent();
//        }

//    }
//}