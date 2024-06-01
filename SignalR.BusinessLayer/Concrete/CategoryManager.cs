using System;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int TActiveCategoryCount()
        {
            return _categoryDal.ActiveCategoryCount();
        }

        public void TAdd(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public string TAtLeastValuableCategory()
        {
            return _categoryDal.AtLeastValuableCategory();
        }

        public int TCategoryCount()
        {
            return _categoryDal.CategoryCount();
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public string TLatestCategory()
        {
            return _categoryDal.LatestCategory();
        }

        public string TMostValuableCategory()
        {
            return _categoryDal.MostValuableCategory();
        }

        public int TPassiveCategoryCount()
        {
            return _categoryDal.PassiveCategoryCount();
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public int TZeroProductCategoryCount()
        {
            return _categoryDal.ZeroProductCategoryCount();
        }
    }
}

