using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogosWeb.Models.Repository.Blog
{
    public interface IBlogRepository
    {
        Models.Blog GetBlogContent();
        Postagem GetPostById(int postId);
    }
}
