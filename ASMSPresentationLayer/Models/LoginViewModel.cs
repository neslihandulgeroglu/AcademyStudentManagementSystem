using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASMSPresentationLayer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email zorunludur!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur !")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Şifreniz minimum 8 maximum 20 haneli olmalıdır!")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
