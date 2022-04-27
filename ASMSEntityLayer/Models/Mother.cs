using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    public class Mother:Base<byte>
    {
        //Table attr yazmıyorum
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "MotherName adı en az 2 en çok 50 karakter aralığında olmalıdır!!")]
        public string MotherName { get; set; }
    }
}
