using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();
        public int TProductCount();
        public decimal TProductPriceAverage();
        public string THighestProductPriceName();
        public string TLowestProductPriceName();
    }
}

