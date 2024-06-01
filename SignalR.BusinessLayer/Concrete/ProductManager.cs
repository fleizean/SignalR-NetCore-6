using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public string THighestProductPriceName()
        {
            return _productDal.HighestProductPriceName();
        }

        public string TLowestProductPriceName()
        {
            return _productDal.LowestProductPriceName();
        }

        public int TProductCount()
        {
            return _productDal.ProductCount();
        }

        public decimal TProductPriceAverage()
        {
            return _productDal.ProductPriceAverage();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}

