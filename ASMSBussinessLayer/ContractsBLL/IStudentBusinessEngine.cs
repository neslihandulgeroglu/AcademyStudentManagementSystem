using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;

namespace ASMSBusinessLayer.ContractsBLL
{
    public interface IStudentBusinessEngine
    {
        IResult Add(StudentVM student);

       // IResult Add(string tc,string userId);

    }
}
