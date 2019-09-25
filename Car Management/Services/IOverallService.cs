using Car_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Services
{
    public interface IOverallService
    {
        void Create(OverallService overallservice);
        IEnumerable<OverallService> GetAllOverallService();
        void Delete(OverallService newService);
        OverallService GetOverllServiceByid(int id);
    }
}
