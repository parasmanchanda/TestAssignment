using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public Guid UId { get; set; }
        [Column("Student_Number")]
        public int StudentNumber { get; set; }
        [Column("First_Name")]
        public string firstName { get; set; }
        [Column("Last_Name")]
        public string lastName { get; set; }
        [Column("Screen_Name")]
        public string Screen_Name { get; set; }
        [Column("Date_Of_Birth")]
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }

        [Column("Country_Code_Id")]
        public int? CountryCodeId { get; set; }
        [ForeignKey("CountryCodeId")]
        public virtual CountryCode CountryCode { get; set; }
        [Column("Phone_Number")]
        public string PhoneNumber { get; set; }
        [Column("Created_By")]
        public int? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
        [Column("Updated_By")]
        public int? UpdatedBy { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User UpdatedByUser { get; set; }
        [Column("Created_On")]
        public DateTime CreatedOn { get; set; }
        [Column("Updated_On")]
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Resources> Resources { get; set; }
    }
}
