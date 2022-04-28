using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;

namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class StudentsCourseGroupRepo:RepositoryBase<StudentsCourseGroup,int>,IStudentsCourseGroupRepo
    {

        public StudentsCourseGroupRepo(MyContext myContext):base(myContext)
        {

        }
    }
}
