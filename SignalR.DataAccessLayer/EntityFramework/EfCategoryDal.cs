using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
	{
		public EfCategoryDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(a => a.Status == true).Count();
		}

		public int CategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Count();
		}

		public string LatestCategory()
		{
			using var context = new SignalRContext();
			var latestCategory = context.Categories.OrderBy(c => c.CategoryID).LastOrDefault();
            return latestCategory != null ? latestCategory.CategoryName : "No category found";
        }

        public int PassiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(a => a.Status == false).Count();
		}

		public int ZeroProductCategoryCount()
		{
            using var context = new SignalRContext();
			return context.Categories.Count(c => c.Products.Count == 0);
        }

        public string AtLeastValuableCategory()
        {
            using var context = new SignalRContext();
            var leastValuableCategory = context.Categories
                .Select(a => new
                {
                    CategoryName = a.CategoryName,
                    ProductCount = a.Products.Count(),
                })
                .OrderBy(a => a.ProductCount)
                .FirstOrDefault();

            return leastValuableCategory != null ? leastValuableCategory.CategoryName : "No category found";
        }

        public string MostValuableCategory()
        {
            using var context = new SignalRContext();
            var mostValuableCategory = context.Categories
                .Select(a => new
                {
                    CategoryName = a.CategoryName,
                    ProductCount = a.Products.Count(),
                })
                .OrderByDescending(a => a.ProductCount)
                .FirstOrDefault();

            return mostValuableCategory != null ? mostValuableCategory.CategoryName : "No category found";
        }
    }
}

