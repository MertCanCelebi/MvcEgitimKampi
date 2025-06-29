using MVC_DataAccessLayer.Concrete.Repositories;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBl()
        {
            return repo.List();
        }
        public void CategoryAddBl(Category p)
        {
            if(p.CategoryName == "" || p.CategoryName.Length > 50)
            {
                //hata mesajı yazılacak
            }
            else
            {
                repo.Insert(p);
                
            }
        }
    }
}
