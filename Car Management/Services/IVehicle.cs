using Cyberservice_management.Enum;
using Cyberservice_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Repository
{
    public interface IVehicle
    {
        void Create(Vehicle newVehicle);
        Vehicle GetByid(int id);
        void Update(Vehicle newVehicle);
        void Delete(Vehicle newVehicle);
        IEnumerable<Vehicle> GetVehicles();
      

    }
}
