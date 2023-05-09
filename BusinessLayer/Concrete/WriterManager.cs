using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

        public List<Writer> GetAllTs()
        {
           return _writerDal.GetList();
        }

        public Writer GetTById(int id)
        {
            return _writerDal.GetByID(id);
        }

        public List<Writer> GetWriterByID(int id)
        {
           return _writerDal.GetListLinq(x=>x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            _writerDal.Delete(t);
        }

        
        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
