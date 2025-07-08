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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public void ContactAddBl(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDeleteBl(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUpdateBl(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(x => x.ContactId == id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
