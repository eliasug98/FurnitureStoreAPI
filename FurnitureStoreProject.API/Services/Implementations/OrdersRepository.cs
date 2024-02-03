using FurnitureStore.API.DBContext;
using FurnitureStore.API.DTOs.OrderDTOs;
using FurnitureStore.API.Entities;
using FurnitureStore.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FurnitureStore.API.Services.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly FurnitureStoreContext _context;
        public OrdersRepository(FurnitureStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders.Include(o => o.OrderDetails);
        }

        public Order? GetOrderById(int id)
        {
            return _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.Orders.Where(o => o.Id == orderId).SelectMany(o => o.OrderDetails);
        }

        public IEnumerable<Order> GetOrdersByUserId(int idUser)
        {
            return _context.Orders.Include(o => o.OrderDetails).Where(o => o.UserId == idUser);
        }

        public bool OrderExists(int idOrder)
        {
            return _context.Orders.Where(o => o.Id == idOrder).Any();
        }

        public void AddOrder(Order order, List<OrderDetail> orderDetails)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            
            _context.OrderDetails.AddRange(orderDetails);
            _context.SaveChanges();
        }

        public void Update(Order order, List<OrderDetail> orderDetails)
        {
            _context.OrderDetails.UpdateRange(orderDetails);
            _context.Orders.Update(order);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool DeleteOrderAndDetails(int orderId)
        {
            //var order = GetOrderById(orderId);
            var order = _context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.Id == orderId); 
            if (order == null)
                return false;
            _context.OrderDetails.RemoveRange(order.OrderDetails);
            _context.Orders.Remove(order);
            return true;
        }

    }
}
