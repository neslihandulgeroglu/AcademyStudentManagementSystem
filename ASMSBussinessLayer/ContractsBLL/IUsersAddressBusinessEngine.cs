using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;

namespace ASMSBusinessLayer.ContractsBLL
{
   public  interface IUsersAddressBusinessEngine
    {
        //EKLEME 
        //DÜZENLEME
        //SİLME 
        //LİSTELEME 
        IResult Add(UsersAddressVM address);
        IDataResult<ICollection<UsersAddressVM>> GetAll(string userId);


       
    }
}
