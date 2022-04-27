using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    [Table("StudentAttendances")]
    public class StudentAttendance : Base<int>
    {
        public int StudentsCourseGroupId { get; set; }
        [DataType(DataType.Date)]
        public DateTime ClassDate { get; set; }
        public bool IsPresent { get; set; }
        
        [ForeignKey("StudentsCourseGroupId")]
        public virtual StudentsCourseGroup StudentsCourseGroup { get; set; }
    }
}
