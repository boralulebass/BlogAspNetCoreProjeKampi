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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public List<Message2> GetAllTs()
        {
            return _message2Dal.GetList();
        }

        public List<Message2> GetAllTWithMessageByWriter(int id)
        {
            return _message2Dal.GetAllWithMessageByWriter(id);
        }

        public List<Message2> GetAllTWithMessageByWriterSendBox(int id)
        {
            return _message2Dal.GetAllWithMessageByWriterSendBox(id);
        }

        public Message2 GetTById(int id)
        {
            return _message2Dal.GetByID(id);
        }

        public void TAdd(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public void TUpdate(Message2 t)
        {
            t.MessageStatus = false;
            _message2Dal.Update(t);
        }
    }
}
