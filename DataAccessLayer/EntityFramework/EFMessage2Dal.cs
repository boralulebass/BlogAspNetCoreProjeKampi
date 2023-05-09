using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFMessage2Dal : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetAllWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x=>x.ReceiverUser).Include(x=>x.SenderUser).Where(x => x.ReceiverID == id).Where(x=>x.MessageStatus==true).ToList();
            }
        }
        public List<Message2> GetAllWithMessageByWriterSendBox(int id)
        {
            using (var c = new Context())
            {
                return c.Messages2.Include(x => x.ReceiverUser).Include(x => x.SenderUser).Where(x => x.SenderID == id).Where(x => x.MessageStatus == true).ToList();
            }
        }
    }
}
