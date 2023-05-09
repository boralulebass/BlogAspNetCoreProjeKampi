using System.ComponentModel.DataAnnotations;

namespace AspNetCoreProjeKampı.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz.")]
        public string nameSurname { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz.")]
        public string Password { get; set; }
        [Display(Name = "Şifre tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Mail")]
        [Required(ErrorMessage = "Lütfen mail adresi giriniz.")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }
    }
}
