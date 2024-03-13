using BLL.DTOModels;
using BLL.ServiceInterfaces;
using DAL;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_EF
{
    public class OrderService : IOrderService
    {
        private readonly WebshpContext _context;

        public OrderService(WebshpContext context)
        {
            _context = context;
        }

        public void GenerateOrderFromBasket(int userId)
        {


            var baskets = _context.BasketPositions.Where(bp => bp.UserID == userId).ToList();
                 

            if (userId == null)
                throw new ArgumentException("User not found.");

            if (!baskets.Any())
                throw new InvalidOperationException("Basket is empty.");

            var order = new Order
            {
                UserID = userId,
                Date = DateTime.Now
            };

            foreach (var basketPosition in baskets )
            {
                var orderPosition = new OrderPosition
                {
                    OrderID = order.ID,
                    Amount = basketPosition.Amount,
                    Price = basketPosition.Product.Price * basketPosition.Amount,
                    Order = order
                };

                order.OrderPositions.Add(orderPosition);
            }

            _context.Orders.Add(order);
            _context.BasketPositions.RemoveRange(baskets); // Usuwamy pozycje koszyka
            _context.SaveChanges();
        }

        public IEnumerable<OrderPositionResponseDTO> GetOrderPositions(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderResponseDTO> GetOrders(string sortBy, int? orderIdFilter, bool? paidStatusFilter)
        {
            throw new NotImplementedException();
        }

        public void PayOrder(int orderId, decimal amountPaid)
        {
            var order = _context.Orders.FirstOrDefault(o => o.ID == orderId);
            if (order == null)
                throw new ArgumentException("Order not found.");

            if (order.IsPayed)
                throw new InvalidOperationException("Order has already been paid.");

            var amountToPay = _context.OrderPositions.Where(x => x.OrderID == orderId).Sum(x => x.Amount);
            if (amountToPay == amountPaid)
            {
                // Aktualizujemy status zamówienia na opłacone
                order.IsPayed = true;

                // Zapisujemy kwotę wpłacaną przez klienta

                _context.SaveChanges();
            }
            else 
            {
                throw new Exception("Amount is not correct");
            }

        }
    }
}
