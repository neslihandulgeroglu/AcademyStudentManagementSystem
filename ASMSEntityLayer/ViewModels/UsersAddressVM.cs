using ASMSEntityLayer.IdentityModels;
using ASMSEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.ViewModels
{
   public  class UsersAddressVM
    {
            public int Id { get; set; }

            public DateTime CreatedDate { get; set; }
            public bool IsDeleted { get; set; }
            public string UserId { get; set; } //AspnetUsers ilişki
           [Required]
           [StringLength(50, MinimumLength = 2, ErrorMessage = "Adres başlığı en az 2 en çok 50 karakter aralığında olmalıdır!!")]
      
           public string AddressTitle { get; set; }
           [Required( ErrorMessage = "Mahalle seçimi zorunludur.")]
           public int NeighbourhoodId { get; set; } //Mahalleyle ilişki
           [StringLength(500, ErrorMessage = "Adres detayı en çok 500 karakter aralığında olabilir!!")]
           public string AddressDetails { get; set; }
           
            public string PostCode { get; set; } // 34000
                                                 //ilişkiler 
            
            public  AppUser AppUser { get; set; }

            public  NeighbourhoodVM Neighbourhood { get; set; }
        //TODO:Aşağıdakilerle il ve ilçeye ulaşabilir miyim?
            public CityVM City { get; set; }
            public  DistrictVM District { get; set; }

    }
}
