using Microsoft.AspNetCore.Mvc;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.Data.Dto;
using YuksekAtesBlog.WebUI.Areas.Admin.Models;

namespace YuksekAtesBlog.WebUI.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly IWebHostEnvironment _environment;
        public PostController(ICategoryService categoryService, IPostService postService, IWebHostEnvironment environment)
        {
            _categoryService = categoryService;
            _postService = postService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var postList = _postService.GetAll();

            var viewModel = postList.Select(x => new PostViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Summary = x.Summary,
                ImagePath = x.ImagePath,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName

            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories;

            return View("Form", new PostFormViewModel());
        }

        [HttpPost]
        public IActionResult Save(PostFormViewModel formdata)
        {
            if (!ModelState.IsValid)
            {
                var categories = _categoryService.GetCategories();
                ViewBag.Categories = categories;

                return View("Form", formdata);
            }

            var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };
            var allowedFileExtensions = new string[] { ".jpeg", ".jpg", "png", ".jfif" };

            var fileContentType = formdata.File.ContentType;
            var fileNameWithoutExtensions = Path.GetFileNameWithoutExtension(formdata.File.FileName);
            var fileExtension = Path.GetExtension(formdata.File.FileName);

            if (formdata.File == null || formdata.File.Length == 0 ||
                !allowedFileContentTypes.Contains(fileContentType) ||
                !allowedFileExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("file", "Lütfen jpg, jpeg, jfif veya png Tipinde Geçerli Bir Dosya Yükleyiniz.");

                var categories = _categoryService.GetCategories();
                ViewBag.Categories = categories;

                return View("Form", formdata);
            }

            var newFileName = fileNameWithoutExtensions + "_" + Guid.NewGuid() + fileExtension;
            var folderPath = Path.Combine("images", "posts");
            var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);
            var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);

            Directory.CreateDirectory(wwwRootFolderPath);

            using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
            {
                formdata.File.CopyTo(fileStream);
            }


            if (formdata.Id == 0)
            {
                var postDto = new PostDto
                {
                    Id = formdata.Id,
                    Name = formdata.Name,
                    Description = formdata.Description,
                    Summary = formdata.Summary,
                    ImagePath = newFileName,
                    CategoryId = formdata.CategoryId
                };

                var response = _postService.AddPost(postDto);

                if (response.IsSucceed)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var categories = _categoryService.GetCategories();
                    ViewBag.Categories = categories;

                    ViewBag.ErrorMessage = response.Message;
                    return View("form", formdata);
                }
            }
            else
            {
                var postDto = new PostDto
                {
                    Id = formdata.Id,
                    Name = formdata.Name,
                    Description = formdata.Description,
                    Summary = formdata.Summary,
                    ImagePath = newFileName,
                    CategoryId = formdata.CategoryId
                };
                if (formdata.File != null)
                {
                    postDto.ImagePath = newFileName;
                }
                _postService.EditPost(postDto);

            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var categories = _categoryService.GetCategories();
            ViewBag.Categories = categories;
            var post = _postService.GetPostById(id);

            var viewModel = new PostFormViewModel()
            {
                Id = post.Id,
                Description = post.Description,
                Name = post.Name,
                Summary = post.Summary,
                CategoryId = post.CategoryId,
            };

            ViewBag.Image = post.ImagePath;

            return View("Form", viewModel);
        }

        public IActionResult Delete(int id)
        {
            _postService.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}
