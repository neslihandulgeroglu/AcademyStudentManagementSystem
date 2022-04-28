using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;

namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class StudentAttendanceRepo:RepositoryBase<StudentAttandance,int>,IStudentAttendanceRepo
    {
        public StudentAttendanceRepo(MyContext myContext):base(myContext)
        {

        }
    }
}
