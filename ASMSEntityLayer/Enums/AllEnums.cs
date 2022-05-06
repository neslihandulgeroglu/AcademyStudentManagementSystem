using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.Enums
{
    public class AllEnums
    {
    }
    public enum Genders : byte
    {
        Male = 0,
        Female = 1,
        Unknown = 2
    }
    public enum ClassLocation : byte
    {
        GirisKat = 0,
        Kat1 = 1,
        Kat2 = 2,
        Kat3 = 3,
        Kat4 = 4,
        Kat5 = 5
    }
    public enum ASMSRoles : byte
    {
        Passive=0,
        Student=1,
        Teacher=2,
        Coordinator=3,
        StudentAdministration=4,
        Manager=5


    }
}
