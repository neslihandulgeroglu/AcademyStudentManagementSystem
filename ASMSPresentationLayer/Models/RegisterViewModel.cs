using ASMSEntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASMSPresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik numarası 11 haneli olmalıdır!")]
        [Display(Name = "TC Kimlik No")]
        public string TCNumber { get; set; }


        [Required(ErrorMessage = "İsim Gereklidir!")]
        [Display(Name = "İsim")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İsminiz en az 2 en çok 50 karakter olmalıdır!")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Soyisim Gereklidir!")]
        [Display(Name = "Soyisim")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyisminiz en az 2 en çok 50 karakter olmalıdır!")]
        public string Surname { get; set; }


        [Required(ErrorMessage = "Email Zorunludur!")]
        [EmailAddress]
        [Display(Name = "Email adresi")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Şifre alanı zorunludur !")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Şifreniz minimum 8 maximum 20 haneli olmalıdır!")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "Cinsiyet Seçimi Gereklidir!")]
        public Genders Gender { get; set; }

    }
}
