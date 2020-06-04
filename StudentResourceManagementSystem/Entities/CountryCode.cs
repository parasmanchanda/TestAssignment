using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class CountryCode
    {
        [Key]
        public int Id { get; set; }
        [Column("Phone_Code")]
        public string PhoneCode { get; set; }
        [Column("Country_Name")]
        public string CountryName { get; set; }
    }
}
