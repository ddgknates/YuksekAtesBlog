using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Business.Types;
using YuksekAtesBlog.Data.Dto;

namespace YuksekAtesBlog.Business.Services
{
    public interface IPostService
    {
        ServiceMessage AddPost(PostDto post);
        List<PostDto> GetAll(int? categoryId = null);
        PostDto GetPostById(int id);
        void EditPost(PostDto post);
        void DeletePost(int id);
    }
}
