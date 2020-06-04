using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Column("Created_On")]
        public DateTime CreatedOn { get; set; }
        [Column("Updated_On")]
        public DateTime UpdatedOn { get; set; }
    }
}
