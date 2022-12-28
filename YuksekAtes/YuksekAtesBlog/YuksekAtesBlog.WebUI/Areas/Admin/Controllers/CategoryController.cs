using Microsoft.AspNetCore.Mvc;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.Data.Dto;
using YuksekAtesBlog.WebUI.Areas.Admin.Models;

namespace YuksekAtesBlog.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categoryList = _categoryService.GetCategories();

            var viewModel = categoryList.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View("Form", new CategoryFormViewModel());
        }

        [HttpPost]
        public IActionResult Save(CategoryFormViewModel formdata)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", formdata);
            }

            var categoryDto = new CategoryDto
            {
                Id = formdata.Id,
                Name = formdata.Name,
            };

            if (formdata.Id == 0)
            {

                var response = _categoryService.AddCategory(categoryDto);

                if (response.IsSucceed)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = response.Message;
                    return View("form", formdata);
                }
            }
            else
            {
                _categoryService.EditCategory(categoryDto);

                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            var viewModel = new CategoryFormViewModel()
            {
                Id = category.Id,
                Name = category.Name,
            };

            return View("Form", viewModel);
        }

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
