﻿using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.DataAccessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.BusinessLayer.Concrete
{
   public class ContentManager  : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);       
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public void TDelete(Content t)
        {
            _contentDal.Delete(t);
        }

        public Content TGetById(int id)
        {
            return _contentDal.GetById(id); 
        }

        public List<Content> TGetList()
        {
            return _contentDal.GetList();
        }

        public void TInsert(Content t)
        {
            _contentDal.Insert(t);
        }



        public void TUpdate(Content t)
        {
            _contentDal.Update(t);
        }
    }
}
