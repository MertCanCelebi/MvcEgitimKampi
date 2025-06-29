using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAddBl(Writer writer);
        Writer GetById(int id);
        void WriterDeleteBl(Writer writer);
        void WriterUpdateBl(Writer writer);
    }
}
