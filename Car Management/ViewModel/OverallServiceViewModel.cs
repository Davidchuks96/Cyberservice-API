using Cyberservice_management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.ViewModel
{
    public class OverallServiceViewModel
    {

        public OverallService overall { get; set; }

        public int OverallServiceId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string SerialNo { get; set; }

        [Required]
        public DateTime RecentDateOfService { get; set; }

        [Required]
        public DateTime NextDateOfService { get; set; }

        public IEnumerable<Service> services { get; set; }
    }
}
