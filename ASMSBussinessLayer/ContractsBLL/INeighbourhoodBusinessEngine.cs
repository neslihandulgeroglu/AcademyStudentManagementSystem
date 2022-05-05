using ASMSEntityLayer.ResultModels;
using ASMSEntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSBusinessLayer.ContractsBLL
{
    public interface INeighbourhoodBusinessEngine
    {
        //Buraya birçok metot gelebilir.
        //Biz şuadna zamanımız kısıtlı olduğu için sadece 
        //işimizin olduğu en krirtik olan metodu yazalım.

        IDataResult<ICollection<NeighbourhoodVM>> GetNeighbourhoodsOfDistrict(byte DistrictId);//bu metot ıd verilen şehirin ilçelerini verir.

    }
}
