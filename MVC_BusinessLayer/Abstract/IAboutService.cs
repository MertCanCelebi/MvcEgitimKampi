using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void AboutAddBl(About about);
        About GetById(int id);
        void AboutDeleteBl(About about);
        void AboutUpdateBl(About about);
    }
}
