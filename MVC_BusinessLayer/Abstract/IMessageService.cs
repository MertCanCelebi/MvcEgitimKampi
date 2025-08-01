﻿using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        void MessageAddBl(Message message);
        Message GetById(int id);
        void MessageDeleteBl(Message message);
        void MessageUpdateBl(Message message);
    }
}
