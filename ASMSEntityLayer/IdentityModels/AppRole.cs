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
    public class AppRole : IdentityRole, IBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(500, ErrorMessage = "Role açıklaması en fazla 500 karakter olmalıdır!")]
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
