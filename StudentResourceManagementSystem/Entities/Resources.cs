using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Resources
    {
        [Key]
        public int Id { get; set; }
        [Column("Resource_Details")]
        public string ResourceDetails { get; set; }
        public float Rate { get; set; }
        public string Location { get; set; }
        [Column("Resource_Ticket_Id")]
        public string ResourceTicketId { get; set; }
        public float TimePeriod { get; set; }
    }
}
