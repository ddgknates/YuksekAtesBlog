using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace YuksekAtesBlog.WebUI.Areas.Admin.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Eski Şifreniz")]
        [Required(ErrorMessage = "Eski şifre alanı boş bırakılamaz.")]
        public string LastPassword { get; set; }
        [MaxLength(15)]
        [Display(Name = " Yeni Şifre")]
        [Required(ErrorMessage = " Şifre alanı boş bırakılamaz.")]
        public string Password { get; set; }

        [Display(Name = "Yeni Şifre Tekrar")]
        [Required(ErrorMessage = " Şifre tekrar alanı boş bırakılamaz.")]
        [Compare(nameof(Password), ErrorMessage = "Şifreler eşleşmiyor.")]
        public string PasswordConfirm { get; set; }
    }
}
