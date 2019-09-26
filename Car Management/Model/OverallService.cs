using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Model
{
    public class OverallService
    {
        [Key]
        public int OverallId { get; set; }

        public string  Name { get; set; }

        public DateTime Time { get; set; }

        public Service service { get; set; }
    }
}
