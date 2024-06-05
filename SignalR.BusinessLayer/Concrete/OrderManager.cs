using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Dtos.Order;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public List<Order> TGetOrdersWithDetails()
        {
            return _orderDal.GetOrdersWithDetails();
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public int TTotalActiveOrderCount()
        {
            return _orderDal.TotalActiveOrderCount();
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }

        public List<ActiveOrdersWithDetails> TGetActiveOrdersWithDetails()
        {
            return _orderDal.GetActiveOrdersWithDetails();
        }

        public List<MostSellingOrdersDto> TMostSellingOrders()
        {
            return _orderDal.MostSellingOrders();
        }
    }
}

