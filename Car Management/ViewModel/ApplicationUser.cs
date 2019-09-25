using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Model
{
    public class ApplicationUser:IdentityUser
    {

        public string FullName { get; set; }
    }
}
