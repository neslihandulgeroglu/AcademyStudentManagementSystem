using ASMSEntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    [Table("Students")]
    public class Student : PersonBase
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }
        // ilişkinin karşılığı öğrencinin kurslarının/eğitimlerinin listesi
        public virtual ICollection<StudentsCourseGroup> Courses { get; set; }
    }
}
