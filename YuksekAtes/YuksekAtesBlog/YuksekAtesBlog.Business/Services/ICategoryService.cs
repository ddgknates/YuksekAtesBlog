using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Business.Types;
using YuksekAtesBlog.Data.Dto;

namespace YuksekAtesBlog.Business.Services
{
    public interface ICategoryService
    {
        ServiceMessage AddCategory(CategoryDto category);
        List<CategoryDto> GetCategories();
        CategoryDto GetCategoryById(int id);
        void EditCategory(CategoryDto category);
        void DeleteCategory(int id);

    }
}
