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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReciverMail == p);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAddBl(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDeleteBl(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdateBl(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
