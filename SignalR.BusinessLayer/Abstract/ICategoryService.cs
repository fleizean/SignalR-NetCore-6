using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface ICategoryService : IGenericService<Category>
    {
        public int TCategoryCount();
        public int TActiveCategoryCount();
        public int TPassiveCategoryCount();
        public string TLatestCategory();
        public int TZeroProductCategoryCount();
        public string TAtLeastValuableCategory();
        public string TMostValuableCategory();
    }
}

