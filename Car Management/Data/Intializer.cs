using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Data
{
    public static class Intializer
    {
        public static async Task Initial(RoleManager<IdentityRole> rolemanager)
        {
            if (!await rolemanager.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                await rolemanager.CreateAsync(users);
            }
            if (!await rolemanager.RoleExistsAsync("User"))
            {
                var users = new IdentityRole("User");
                await rolemanager.CreateAsync(users);
            }
        }
    }
}
