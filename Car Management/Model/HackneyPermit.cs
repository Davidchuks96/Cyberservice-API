using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Car_Management.Enum.DStatus;

namespace Car_Management.Model
{
    public class HackneyPermit
    {
        public DateTime IssuedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DocumentStatus H_Status { get; set; }

        public HackneyPermit()
        {
            H_Status = DocumentStatus.Active;
        }

    }
    
}
