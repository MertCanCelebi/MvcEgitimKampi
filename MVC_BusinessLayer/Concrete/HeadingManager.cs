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
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }
        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x=> x.WriterId == id);
        }

        public void HeadingAddBl(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDeleteBl(Heading heading)
        {
            if (heading.HeadingStatus == true)
            {
                heading.HeadingStatus = false;
            }
            else
            {
                heading.HeadingStatus = true;
            }
            _headingDal.Update(heading);
        }

        public void HeadingUpdateBl(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
