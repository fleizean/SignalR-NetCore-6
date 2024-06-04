using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IDiscountDal : IGenericDal<Discount>
    {
        List<Discount> GetDiscountsWithProducts();

        string LastDiscountProduct();
        int MostDiscountAmount();
    }
}

