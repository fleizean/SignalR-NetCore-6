using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            _moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(MoneyCase entity)
        {
            _moneyCaseDal.Add(entity);
        }

        public void TDelete(MoneyCase entity)
        {
            _moneyCaseDal.Delete(entity);
        }

        public MoneyCase TGetById(int id)
        {
            return _moneyCaseDal.GetById(id);
        }

        public List<MoneyCase> TGetListAll()
        {
            return _moneyCaseDal.GetListAll();
        }

        public decimal TTotalPriceMoneyCase()
        {
            return _moneyCaseDal.TotalPriceMoneyCase();
        }

        public void TUpdate(MoneyCase entity)
        {
            _moneyCaseDal.Update(entity);
        }
    }
}

