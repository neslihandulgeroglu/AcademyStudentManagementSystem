using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.ResultModels
{
    public class ErrorResult:Result 
    {
        public ErrorResult():base(false)
        {

        }
        public ErrorResult(string errormessage):base(false,errormessage)
        {

        }
    }
}
