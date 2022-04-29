using ASMSEntityLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.ViewModels
{
  public  class DistrictVM
    {
      
        public int Id { get; set; }

       
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İlçe adı en az 2 en çok 50 karakter aralığında olmalıdır!!")]
        public string DistrictName { get; set; }
     
        public byte CityId { get; set; }
        
        public  CityVM City { get; set; }
        public  ICollection<Neighbourhood> Neighbourhoods { get; set; }


    }
}
