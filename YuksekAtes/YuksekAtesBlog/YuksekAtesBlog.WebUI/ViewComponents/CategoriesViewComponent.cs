using Microsoft.AspNetCore.Mvc;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.WebUI.Models;

namespace YuksekAtesBlog.WebUI.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetCategories();

            var viewModel = categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return View(viewModel);
        }
    }
}
