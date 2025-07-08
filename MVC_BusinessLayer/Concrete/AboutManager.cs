using MVC_BusinessLayer.Abstract;
using MVC_DataAccessLayer.Abstract;
using MVC_DataAccessLayer.EntityFramework;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        public void AboutAddBl(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDeleteBl(About about)
        {
            _aboutDal.Delete(about);
        }

        public void AboutUpdateBl(About about)
        {
            _aboutDal.Update(about);
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x => x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }
    }
}
