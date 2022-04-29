using ASMSEntityLayer.Models;
using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSBusinessLayer.ContractsBLL
{
    public interface ICityBusinessEngine
    {
        IResult Add(CityVM city);
        IResult Delete(CityVM city);
        IResult Update(CityVM city);
        IDataResult<CityVM> GetById(int cityId);
        IDataResult<ICollection<CityVM>> GetAll();
        IDataResult<CityVM> GetFirstOrDefault();
    

        
    }
}
