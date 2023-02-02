using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            // iş kodları
            List<Category> listem = new List<Category>();
            listem = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(listem);

            //return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int id)
        {
            // iş kodları
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id));
        }
    }
}
