using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Models
{
    public interface IBase
    {
        DateTime CreatedDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
