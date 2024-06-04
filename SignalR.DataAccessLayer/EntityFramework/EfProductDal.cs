using System;
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
            using var context = new SignalRContext();
            return context.Products.Include(d => d.Category).ToList();
        }
        
        public string HighestProductPriceName()
        {
            using var context = new SignalRContext();
            var product = context.Products.Where(a => a.Price == (context.Products.Max(y => y.Price))).FirstOrDefault();
            return product != null ? product.ProductName : "No found";
        }

        public string LowestProductPriceName()
        {
            using var context = new SignalRContext();
            var product = context.Products.Where(a => a.Price == (context.Products.Min(y => y.Price))).FirstOrDefault();
            return product != null ? product.ProductName : "No found";
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public decimal ProductPriceAverage()
        {
            using var context = new SignalRContext();
            return context.Products.Average(a => a.Price);
        }
    }
}

