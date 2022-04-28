using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSDataAccessLayer.ContractsDAL;
using ASMSEntityLayer.Models;

namespace ASMSDataAccessLayer.ImplementationsDAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _myContext;
        public UnitOfWork(MyContext myContext)
        {
            _myContext = myContext;
            CityRepo = new CityRepo(_myContext);
            ClassRepo = new ClassRepo(_myContext);
            CourseRepo = new CourseRepo(_myContext);
            CourseGroupRepo = new CourseGroupRepo(_myContext);
            DistrictRepo = new DistrictRepo(_myContext);
            NeighbourhoodRepo = new NeighbourhoodRepo(_myContext);
            StudentAttendanceRepo = new StudentAttendanceRepo(_myContext);
            StudentRepo = new StudentRepo(_myContext);
            StudentsCourseGroupRepo = new StudentsCourseGroupRepo(_myContext);
            TeacherRepo = new TeacherRepo(_myContext);
            UsersAddressRepo = new UsersAddressRepo(_myContext);
        }
        public ICityRepo CityRepo {get;}
        public IClassRepo ClassRepo {get;}
        public ICourseGroupRepo CourseGroupRepo {get;}
        public ICourseRepo CourseRepo {get;}
        public IDistrictRepo DistrictRepo {get;}
        public INeighbourhoodRepo NeighbourhoodRepo {get;}
        public IStudentRepo StudentRepo {get;}
        public IStudentsCourseGroupRepo StudentsCourseGroupRepo {get;}
        public ITeacherRepo TeacherRepo {get;}
        public IStudentAttendanceRepo StudentAttendanceRepo {get;}
        public IUsersAddressRepo UsersAddressRepo {get;}

        public ICourseGroupRepo CourserGroupRepo { get; }

        public IStudentAttendanceRepo StudentAttandanceRepo { get; }
    }
}
