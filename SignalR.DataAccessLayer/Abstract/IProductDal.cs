﻿using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IProductDal : IGenericDal<Product>
    {
		List<Product> GetProductsWithCategories();

		int ProductCount();

		decimal ProductPriceAverage();
        string LowestProductPriceName();
        string HighestProductPriceName();
    }
}
