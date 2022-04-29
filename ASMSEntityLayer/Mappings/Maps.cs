using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASMSEntityLayer.Models;
using ASMSEntityLayer.ViewModels;
using AutoMapper;

namespace ASMSEntityLayer.Mappings
{
    public class Maps:Profile
    {
        //Buraya createMap metodu gelecektir.
        //buraya createaMap metodu gelecektir.
        public Maps()
        {

            //UserAddress'ı UserAddressesVM 'ye dönüştür.
           // CreateMap<UsersAddress, UsersAddressVM>();//DAL--->BLL
            //Yukarıdakinin aynısını tek seferde yapmak mumkun.
           // CreateMap<UsersAddressVM, UsersAddress>();//PlatformID-->BLL--->DAL
            //UserAddress ve VM 'yi birbirine dönüştür.
            CreateMap<UsersAddress, UsersAddressVM>().ReverseMap();
        }

    }
}
