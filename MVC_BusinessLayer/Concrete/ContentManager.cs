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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }
        public void ContentAddBl(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDeleteBl(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdateBl(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId == id);
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }
    }
}
