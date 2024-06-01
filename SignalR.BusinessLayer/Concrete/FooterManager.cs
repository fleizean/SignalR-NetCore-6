using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.EntityFramework;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class FooterManager : IFooterService
    {
        private readonly IFooterDal _footerDal;

        public FooterManager(IFooterDal footerDal)
        {
            _footerDal = footerDal;
        }

        public void TAdd(Footer entity)
        {
            _footerDal.Add(entity);
        }

        public void TDelete(Footer entity)
        {
            _footerDal.Delete(entity);
        }

        public Footer TGetById(int id)
        {
            return _footerDal.GetById(id);
        }

        public List<Footer> TGetListAll()
        {
            return _footerDal.GetListAll();
        }

        public void TUpdate(Footer entity)
        {
            _footerDal.Update(entity);
        }
    }

}


