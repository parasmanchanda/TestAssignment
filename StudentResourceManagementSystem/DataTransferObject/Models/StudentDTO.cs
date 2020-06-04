using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataTransferObject.Models
{
    public class StudentDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Screen_Name { get; set; }
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }
        public int? CountryCodeId { get; set; }
        public string PhoneNumber { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual UserDTO UpdatedByUser { get; set; }

        [Required(ErrorMessage ="Atleast One resource is required")]
        public virtual ICollection<ResourceDTO> Resources { get; set; }
    }
}
