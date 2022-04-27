using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    [Table("StudentsCourseGroups")]
    public class StudentsCourseGroup : Base<int>
    {
        //Öğrencinin kurslarının bilgisi bu tabloda olacak
        //ÖRN Merve x eğitimini alıyor
        public string StudentTCNumber { get; set; }
        public int CourseGroupId { get; set; }
        public bool IsGraduated { get; set; }
        public double GraduationScore { get; set; }
        //ilişkiler
        [ForeignKey("StudentTCNumber")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseGroupId")]
        public virtual CourseGroup CourseGroup { get; set; }

        //ilişki karşılığı
        public virtual ICollection<StudentAttendance> StudentAttendances { get; set; }
    }
}
