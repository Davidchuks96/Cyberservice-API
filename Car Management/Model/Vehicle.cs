using Car_Management.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Car_Management.Enum.DStatus;

namespace Car_Management.Model
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
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
        
        [Required]
        public DateTime VehicleLicenseIssuedDate { get; set; }

        [Required]
        public DateTime VehicleLicenseExpirationDate { get; set; }

        [Required]
        public DateTime IssuranceIssuedDate { get; set; }

        [Required]
        public DateTime IssuranceExpirationDate { get; set; }

        [Required]
        public DateTime RoadWorthinessIssuedDate { get; set; }

        [Required]
        public DateTime RoadWorthinessExpirationDate { get; set; }

        [Required]
        public DateTime HackneyPermitIssuedDate { get; set; }

        [Required]
        public DateTime HackneyPermitExpirationDate { get; set; }

        public DocumentStatus Status{ get; set; }

        public Vehicle()
        {
            Status = DocumentStatus.Active;
        }



    }
}
