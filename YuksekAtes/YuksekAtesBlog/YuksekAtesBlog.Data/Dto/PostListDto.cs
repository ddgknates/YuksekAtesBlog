using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Data.Entities;

namespace YuksekAtesBlog.Data.Dto
{
    public class PostListDto
    {
        public List<PostDto> Posts { get; set; }
        public PostEntity  Post { get; set; }
    }
}
