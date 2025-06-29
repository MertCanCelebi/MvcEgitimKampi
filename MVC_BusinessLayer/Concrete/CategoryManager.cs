using MVC_BusinessLayer.Abstract;
using MVC_DataAccessLayer.Abstract;
using MVC_DataAccessLayer.Concrete.Repositories;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAddBl(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDeleteBl(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdateBl(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x=>x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }
    }
}
