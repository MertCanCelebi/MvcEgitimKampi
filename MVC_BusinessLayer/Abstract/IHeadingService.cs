using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAddBl(Heading heading);
        Heading GetById(int id);
        void HeadingDeleteBl(Heading heading);
        void HeadingUpdateBl(Heading heading);
    }
}
