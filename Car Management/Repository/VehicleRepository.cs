
using Cyberservice_management.Data;
using Cyberservice_management.Enum;
using Cyberservice_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Repository
{
    public class VehicleRepository:IVehicle
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Vehicle newVehicle)
        {
            //  await _context.Set<Vehicle>().AddAsync(newVehicle);
            //await _context.SaveChangesAsync();
            _context.Set<Vehicle>().Add(newVehicle);
            _context.SaveChanges();
        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            return _context.Set<Vehicle>().ToList();
        }

        public Vehicle GetByid(int id)
        {
            return _context.Vehicles.FirstOrDefault(v => v.Id == id);
        }

        public void Update(Vehicle newVehicle)
        {
            {
                _context.Set<Vehicle>().Update(newVehicle);
                _context.SaveChangesAsync();
            }
        }

        public void Delete(Vehicle newVehicle)
        {
            {
                _context.Set<Vehicle>().Remove(newVehicle);
                _context.SaveChangesAsync();
            }
        }
    }
}
