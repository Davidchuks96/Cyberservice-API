using Car_Management.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Model
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        public VehicleType VehicleType{ get; set; }
        [Required]
        public string VehicleName { get; set; }
        [Required]
        public string RegNo { get; set; }
        [Required]
        public string Officers { get; set; }

        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }

        public VehicleLicense VehicleLicense { get; set; }

        public Issurance Issurance { get; set; }

        public HackneyPermit Hackneypermit { get; set; }

        public RoadWorthiness RoadWorthiness { get; set; }

    }
}
