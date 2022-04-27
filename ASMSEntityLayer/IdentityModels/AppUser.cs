using ASMSEntityLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.Models;

namespace ASMSEntityLayer.IdentityModels
{
    public class AppUser : IdentityUser, IBase
    {
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "İsim Gereklidir!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İsminiz en az 2 en çok 50 karakter olmalıdır!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim Gereklidir!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyisminiz en az 2 en çok 50 karakter olmalıdır!")]
        public string Surname { get; set; }
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC 11 haneli olmalıdır!")]
        public string TCNumber { get; set; }
        public string Picture { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Cinsiyet seçimi Gereklidir!")]
        public Genders Gender { get; set; }
        public bool IsDeleted { get; set; } = false;

        // ilişkiler
        public virtual ICollection<UsersAddress> UsersAddresses { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}
