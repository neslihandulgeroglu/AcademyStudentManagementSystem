
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    [Table("Cities")]
    [Index(nameof(PlateCode), IsUnique = true)]
    public class City : Base<byte>
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İl adı en az 2 en çok 50 karakter aralığında olmalıdır!!")]
        public string CityName { get; set; }

        [Required]
        // TODO is unique core da nasıl yapılır?
        public byte PlateCode { get; set; }

        //İlişkiler kurulacak
        public virtual ICollection<District> Districts { get; set; }
        //Yukarıdakin kullanırsak .ToList() yapmak gerekiyor
        //Eriniyorsak .ToList() yapmaya aşağıdakini kullanırız
        //  public virtual List<District> Districts { get; set; }
    }
}
