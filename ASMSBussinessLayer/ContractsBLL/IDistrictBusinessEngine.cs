using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSBusinessLayer.ContractsBLL
{
   public interface IDistrictBusinessEngine
    {
        //Buraya ekleme silme güncelleme vb metot imzaları yazılabilir.
        //biz suanda sadece ihtiyacımız olanalrı yazalım.
        //</summary>
        IDataResult<ICollection<DistrictVM>> GetAllDistricts();//bu metot tüm ilçeleri getirir.
        IDataResult<ICollection<DistrictVM>> GetDistrictsOfCity(byte cityId);//bu metot ıd verilen şehirin ilçelerini verir.

    }
}
