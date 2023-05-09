using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBlogService : IGenericService<Blog>
	{

		List<Blog> GetListLinqBlog(int id);
		List<Blog> GetAllWithCategoryWriter();
		List<Blog> GeTBlogListByWriter(int id);
		List<Blog> GetLast3Blogs();
		List<Blog> GetListIncludedByWriter(int id);
    }
}
