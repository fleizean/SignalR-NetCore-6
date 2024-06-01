using System;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfFooterDal : GenericRepository<Footer>, IFooterDal
    {
        public EfFooterDal(SignalRContext context) : base(context)
        {
        }
    }
}

