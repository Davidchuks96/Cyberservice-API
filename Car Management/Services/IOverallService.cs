using Cyberservice_management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Services
{
    public interface IOverallService
    {
        void Create(OverallService overallservice);
        IEnumerable<OverallService> GetAllOverallService();
        void Delete(OverallService newService);
        OverallService GetOverallServiceByid(int id);
    }
}
