using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IBasketService : IGenericService<Basket>
    {
        public List<Basket> TGetBaskeyByMenuTableNumber(int id);
    }
}

