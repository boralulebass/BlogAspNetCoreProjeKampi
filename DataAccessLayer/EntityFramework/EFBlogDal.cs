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
    public class EFBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAllWithCategoryWriter()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(b => b.Category).Include(x=>x.AppUser).ToList();
            }
        }

        public List<Blog> GetAllWithCWByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(b => b.Category).Include(c=>c.Writer).Where(x=>x.AppUserID == id).ToList();
            }
        }
    }
}
