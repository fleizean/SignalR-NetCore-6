﻿using System;
using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
    {
		public EfProductDal(SignalRContext context) : base(context)
        {
		}

        public List<Product> GetProductsWithCategories()
        {
            var context = new SignalRContext();
            return context.Products.Include(d => d.Category).ToList();
        }
    }
}

