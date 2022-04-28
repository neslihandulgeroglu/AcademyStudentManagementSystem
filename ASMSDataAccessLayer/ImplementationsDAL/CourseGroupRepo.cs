using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;

namespace ASMSDataAccessLayer.ImplementationsDAL
{
   public  class CourseGroupRepo:RepositoryBase<CourseGroup,int>,ICourseGroupRepo
    {
        public CourseGroupRepo(MyContext myContext):base (myContext)
        {

        }
    }
}
