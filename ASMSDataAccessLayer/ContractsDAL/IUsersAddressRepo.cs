using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.Models;
using ASMSDataAccessLayer.ContractsDAL;

namespace ASMSDataAccessLayer.ContractsDAL
{
    public interface IUsersAddressRepo:IRepositoryBase<UsersAddress,int> 
    {
        
    }
}
