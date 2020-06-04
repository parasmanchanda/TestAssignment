using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject.Models
{
    public class ResourceDTO
    {
        public string ResourceDetails { get; set; }
        public float Rate { get; set; }
        public string Location { get; set; }
        public string ResourceTicketId { get; set; }
        public float TimePeriod { get; set; }
    }
}
