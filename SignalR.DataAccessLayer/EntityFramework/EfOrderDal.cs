using System;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Dtos.Order;
using SignalR.DataAccessLayer.Dtos.Product;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public List<Order> GetOrdersWithDetails()
        {
            using var context = new SignalRContext();
            return context.Orders.Include(o => o.OrderDetail).ToList();
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            var lastOrder = context.Orders.OrderByDescending(o => o.Date).FirstOrDefault();
            return lastOrder?.TotalPrice ?? 0;
        }

        public int TotalActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count(a => a.Status == true);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(o => o.Date == DateTime.Today).Sum(o => o.TotalPrice);
        }

        public List<ActiveOrdersWithDetails> GetActiveOrdersWithDetails()
        {
            using var context = new SignalRContext();
            var activeOrdersWithDetails = context.Orders
                .Include(o => o.MenuTable) // Include MenuTable in the query
                .Include(o => o.OrderDetail) // Include OrderDetail in the query
                    .ThenInclude(od => od.Product) // Include Product in the query
                .Where(o => o.Status) // Assuming there is a Status property in Order
                .SelectMany(o => o.OrderDetail, (o, od) => new { Order = o, OrderDetail = od })
                .Select(o => new ActiveOrdersWithDetails
                {
                    OrderID = o.Order.OrderID,
                    TotalPrice = o.Order.TotalPrice,
                    MenuTableName = o.Order.MenuTable.Name, // Get MenuTableName from MenuTable
                    Count = o.OrderDetail.Count,
                    UnitPrice = o.OrderDetail.UnitPrice,
                    Product = new ResultProductDto
                    {
                        ProductID = o.OrderDetail.Product.ProductID,
                        ProductName = o.OrderDetail.Product.ProductName,
                        Description = o.OrderDetail.Product.Description,
                        Price = o.OrderDetail.Product.Price,
                        ImageUrl = o.OrderDetail.Product.ImageUrl,
                        Status = o.OrderDetail.Product.Status
                    }
                })
                .ToList();

            return activeOrdersWithDetails;
        }

        public List<MostSellingOrdersDto> MostSellingOrders()
        {
            using var context = new SignalRContext();
            var mostSellingOrders = context.Orders
                .Include(o => o.OrderDetail)
                .ThenInclude(od => od.Product)
                .SelectMany(o => o.OrderDetail)
                .GroupBy(od => od.Product.ProductName)
                .Select(g => new MostSellingOrdersDto
                {
                    ProductName = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(g => g.Count)
                .ToList();

            return mostSellingOrders;
        }
    }
}

