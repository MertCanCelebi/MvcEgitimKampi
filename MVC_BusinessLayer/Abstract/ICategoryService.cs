using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAddBl(Category category);
        Category GetById(int id);
        void CategoryDeleteBl(Category category);   
        void CategoryUpdateBl(Category category);

    }
}
