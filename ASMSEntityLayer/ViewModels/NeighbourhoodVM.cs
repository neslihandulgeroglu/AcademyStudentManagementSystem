using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMSEntityLayer.ViewModels
{
    public class NeighbourhoodVM
    {
        
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Mahalle adı en az 2 en çok 50 karakter aralığında olmalıdır!!")]
        public string NeighbourhoodName { get; set; }
        //ilişki ilçeyle
        public int DistrictId { get; set; }
        
        public DistrictVM District { get; set; }
        // ilişki
        public  ICollection<UsersAddressVM> UsersAddresses { get; set; }
    }
}
