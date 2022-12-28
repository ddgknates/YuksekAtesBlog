using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace YuksekAtesBlog.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Kategori Adı Girmek Zorunludur.")]
        public string Name { get; set; }

    }
}

