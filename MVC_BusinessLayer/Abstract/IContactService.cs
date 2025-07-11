using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void ContactAddBl(Contact contact);
        Contact GetById(int id);
        void ContactDeleteBl(Contact contact);
        void ContactUpdateBl(Contact contact);
    }
}
