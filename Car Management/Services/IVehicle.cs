using Car_Management.Enum;
using Car_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Repository
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
