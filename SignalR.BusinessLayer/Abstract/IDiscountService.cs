using System;
using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IDiscountService : IGenericService<Discount>
    {
        List<Discount> TGetDiscountsWithProducts();
    }
}

