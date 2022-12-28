using Microsoft.AspNetCore.Mvc;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.WebUI.Models;

namespace YuksekAtesBlog.WebUI.ViewComponents
{
    public class PostsViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        public PostsViewComponent(IPostService postService)
        {
            _postService = postService;
        }
        public IViewComponentResult Invoke(int? categoryId = null)
        {

            var posts = _postService.GetAll(categoryId);

            var viewModel = posts.Select(x => new PostViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Summary = x.Summary,
                ImagePath = x.ImagePath,
                CategoryId = x.CategoryId
            }).ToList();

            return View(viewModel);
        }
    }
}

