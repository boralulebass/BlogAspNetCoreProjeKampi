using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessage2Service : IGenericService<Message2>
    {
        public List<Message2> GetAllTWithMessageByWriter(int id);
        public List<Message2> GetAllTWithMessageByWriterSendBox(int id);
    }
}
