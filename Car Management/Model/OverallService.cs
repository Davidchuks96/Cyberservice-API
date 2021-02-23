using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Model
{
    public class OverallService
    {
        [Key]
        public int OverallServiceId { get; set; }

        public string  Name { get; set; }

        public DateTime Time { get; set; }

        public IEnumerable <Service> services { get; set; }
    }
}
