using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingId(int id);
        void ContentAddBl(Content content);
        Content GetById(int id);
        void ContentDeleteBl(Content content);
        void ContentUpdateBl(Content content);
    }
}
