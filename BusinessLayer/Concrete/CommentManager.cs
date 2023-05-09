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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetAllCommentsByID(int id)
        {
            return _commentDal.GetListLinq(x => x.BlogID == id);
        }

        public List<Comment> GetAllTs()
        {
            return _commentDal.GetList();
        }

        public Comment GetTById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> GetTCommentsIncluded()
        {
            return _commentDal.GetCommentsIncluded();
        }

        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.Update(t);
        }
    }
}
