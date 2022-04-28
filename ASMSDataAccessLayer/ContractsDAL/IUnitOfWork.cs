using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSDataAccessLayer.ContractsDAL
{
    public interface IUnitOfWork
    {
        ICityRepo CityRepo { get;  }
        IClassRepo ClassRepo { get;  }
        ICourseGroupRepo CourserGroupRepo { get;  }
        ICourseRepo CourseRepo { get;  }
        IDistrictRepo DistrictRepo { get;  }
        INeighbourhoodRepo NeighbourhoodRepo { get;  }
        IStudentRepo StudentRepo { get;  }
        IStudentsCourseGroupRepo StudentsCourseGroupRepo { get;  }
        ITeacherRepo TeacherRepo { get;  }
        IStudentAttendanceRepo StudentAttandanceRepo { get;  }

        IUsersAddressRepo UsersAddressRepo { get;  }

    }
}
