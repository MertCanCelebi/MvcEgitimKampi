﻿using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.Abstract
{
    public interface IWriterLoginService
    {
        Writer GetWriter(string username, string password);
    }
}
