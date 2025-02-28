using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Interfaces.BlogInterface
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlogsWithAuthors();
        public List<Blog> GetAllBlogsWithAuthor();
        public List<Blog> GetBlogByAuthorId(int id);
    }
}
