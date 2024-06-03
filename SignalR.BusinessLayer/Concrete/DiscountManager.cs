using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _discountDal;

        public DiscountManager(IDiscountDal discountDal)
        {
            _discountDal = discountDal;
        }

        public void TAdd(Discount entity)
        {
            _discountDal.Add(entity);
        }

        public void TDelete(Discount entity)
        {
            _discountDal.Delete(entity);
        }

        public Discount TGetById(int id)
        {
            return _discountDal.GetById(id);
        }

        public List<Discount> TGetDiscountsWithProducts()
        {
            return _discountDal.GetDiscountsWithProducts();
        }

        public List<Discount> TGetListAll()
        {
            return _discountDal.GetListAll();
        }

        public string TLastDiscountProduct()
        {
            return _discountDal.LastDiscountProduct();
        }

        public int TMostDiscountAmount()
        {
            return _discountDal.MostDiscountAmount();
        }

        public void TUpdate(Discount entity)
        {
            _discountDal.Update(entity);
        }
    }
}

