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
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}


        public List<Blog> GetAllWithCategoryWriter()
        {
            return _blogDal.GetAllWithCategoryWriter();
        }
        public List<Blog> GetListIncludedByWriter(int id)
        {
            return _blogDal.GetAllWithCWByWriter(id);
        }
		public List<Blog> GetLast3Blogs()
		{
			return _blogDal.GetList().Take(3).ToList();
		}


		public List<Blog> GeTBlogListByWriter(int id)
		{
			return _blogDal.GetListLinq(x=>x.AppUserID == id);
		}

		public List<Blog> GetListLinqBlog(int id)
		{
		  return _blogDal.GetListLinq(x=>x.BlogID == id);
		}

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
           _blogDal.Update(t);
        }

        public List<Blog> GetAllTs()
        {
            return _blogDal.GetList();
        }

        public Blog GetTById(int id)
        {
            return _blogDal.GetByID(id);
        }
    }
}
