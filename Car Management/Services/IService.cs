using Cyberservice_management.Model;
using Cyberservice_management.Repository;
using Cyberservice_management.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cyberservice_management.Repository
{
    public interface IService
    {
        Service GetByid(int? id);
        OverallService Create(OverallServiceViewModel viewModel);
        void Delete(Service newService);
        Service GetServiceById(int id);
        IEnumerable<Service> GetAll();
        IEnumerable<Service> GetByName(string name);
        IEnumerable<Service> GetByDescription(string description);
       // IEnumerable<Service> GetBySerialNo(string serialno);
        void Update( Service newService);
        void Add(Service service);
        OverallService GetOverallServiceById(int OverallServiceId);

    }
}