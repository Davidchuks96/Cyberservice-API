using Car_Management.Model;
using Car_Management.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Management.Repository
{
    public interface IService
    {
        Service GetBy(int? id);
        void Create(Service service);
        void Delete(int? id,Service newService);
        IEnumerable<Service> GetAll();
        IEnumerable<Service> GetByName(string name);
        IEnumerable<Service> GetByDescription(string description);
        IEnumerable<Service> GetBySerialNo(string serialno);
        void Update(int? id, Service newService);
        void Create(OverallService overall);
    }
}