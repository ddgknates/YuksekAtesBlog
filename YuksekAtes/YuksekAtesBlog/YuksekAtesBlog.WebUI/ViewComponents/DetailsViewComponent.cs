using Microsoft.AspNetCore.Mvc;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.WebUI.Areas.Admin.Models;

namespace YuksekAtesBlog.WebUI.ViewComponents
{
    public class DetailsViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        public DetailsViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var post = _postService.GetPostById(id);
            var viewModel = new PostViewModel()
            {
                Id = post.Id,
                Name = post.Name,
                Description = post.Description,
                Summary = post.Summary,
                ImagePath = post.ImagePath,
                CategoryId = post.CategoryId
            };

            return View(viewModel);
        }        
    }
}
