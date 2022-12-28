using Microsoft.AspNetCore.Mvc;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.WebUI.Models;
using YuksekAtesBlog.Data.Entities;

namespace YuksekAtesBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IAdminService _adminService;
        public HomeController(IPostService postService, IAdminService adminService)
        {
            _postService = postService;
            _adminService = adminService;
        }

        [Route("/")]
        [Route("posts/{categoryName}/{categoryId}/{postName?}/{postId?}")]
        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
            //var viewModel = new PostListViewModel
            //{
            //    Posts = _postService.GetAll()
            //};
            return View();
        }

        [Route("Tarif")]
        public IActionResult Details(int id)
        {
            var posts = _postService.GetPostById(id);
            var viewModel = new PostViewModel
            {
                Id = posts.Id,
                Name = posts.Name,
                ImagePath = posts.ImagePath,
                Description = posts.Description,
                Summary = posts.Summary,
            };
            return View(viewModel);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            var posts = _postService.GetAll();
            var viewModel = posts.Select(x =>  new PostViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                Description = x.Description,
                Summary = x.Summary,
            }).ToList();            
            return View(viewModel);
        }

    }
}
