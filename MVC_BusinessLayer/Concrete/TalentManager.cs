﻿using MVC_BusinessLayer.Abstract;
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
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }
        public Talent GetById(int id)
        {
            return _talentDal.Get(x => x.TalentID == id);
        }

        public List<Talent> GetList()
        {
            return _talentDal.List();
        }

        public void TalentAddBl(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public void TalentDeleteBl(Talent talent)
        {
            _talentDal.Delete(talent);
        }

        public void TalentUpdateBl(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
