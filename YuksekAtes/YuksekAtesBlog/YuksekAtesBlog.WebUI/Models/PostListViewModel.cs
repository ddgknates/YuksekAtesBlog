using YuksekAtesBlog.Data.Dto;

namespace YuksekAtesBlog.WebUI.Models
{
    public class PostListViewModel
    {
        public List<PostDto> Posts { get; set; }
        public PostListDto? Post { get; set; }
    }
}
