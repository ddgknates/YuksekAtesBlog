using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace YuksekAtesBlog.WebUI.Areas.Admin.Models
{
    public class PostFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lüften Bir Başlık Giriniz.")]
        [Display(Name = "Başlık")]
        public string Name { get; set; }
        [Display(Name = "Özet")]
        public string Summary { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Ürün Görseli")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Kategori Seçiniz.")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
    }
}
