using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Model
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        //[Required]
       // public string SerialNo { get; set; }
        [Required]
        public DateTime RecentDateOfService { get; set; }
        [Required]
        public DateTime NextDateOfService { get; set; }

        public int OverallServiceId { get; set; }
    }
}
