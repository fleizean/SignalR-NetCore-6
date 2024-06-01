using System;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface ICategoryDal : IGenericDal<Category>
    {
		int CategoryCount();
		int ActiveCategoryCount();
		int PassiveCategoryCount();
		string LatestCategory();
		string MostValuableCategory();
		string AtLeastValuableCategory();
		int ZeroProductCategoryCount();
	}
}

