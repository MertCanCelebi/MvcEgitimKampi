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
    public class WriterManager
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void WriterAddBl(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDeleteBl(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdateBl(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
