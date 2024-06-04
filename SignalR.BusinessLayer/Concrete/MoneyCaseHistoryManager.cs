using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class MoneyCaseHistoryManager : IMoneyCaseHistoryService
    {
        private readonly IMoneyCaseHistoryDal _moneyCaseHistoryDal;

        public MoneyCaseHistoryManager(IMoneyCaseHistoryDal moneyCaseHistoryDal)
        {
            _moneyCaseHistoryDal = moneyCaseHistoryDal;
        }

        public void TAdd(MoneyCaseHistory entity)
        {
            _moneyCaseHistoryDal.Add(entity);
        }

        public void TDelete(MoneyCaseHistory entity)
        {
            _moneyCaseHistoryDal.Delete(entity);
        }

        public MoneyCaseHistory TGetById(int id)
        {
            return _moneyCaseHistoryDal.GetById(id);
        }

        public List<MoneyCaseHistory> TGetListAll()
        {
            return _moneyCaseHistoryDal.GetListAll();
        }

        public List<MoneyCaseHistory> TMoneyCaseHistories()
        {
            return _moneyCaseHistoryDal.MoneyCaseHistories();
        }

        public void TUpdate(MoneyCaseHistory entity)
        {
            _moneyCaseHistoryDal.Update(entity);
        }
    }
}

