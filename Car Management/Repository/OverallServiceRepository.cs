using Cyberservice_management.Data;
using Cyberservice_management.Model;
using Cyberservice_management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyberservice_management.Repository
{
    public class OverallServiceRepository:IOverallService
    {
        private readonly ApplicationDbContext _context;

        public OverallServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(OverallService newOverallService)
        {
             _context.Set<OverallService>().AddAsync(newOverallService);
             _context.SaveChanges();
        }

        public IEnumerable<OverallService> GetAllOverallService()
        {
            return _context.Overall.ToList();
        }

        public void Delete(OverallService newService)
        {
            {
                _context.Set<OverallService>().Remove(newService);
                _context.SaveChanges();
            }
        }
        public OverallService GetOverallServiceByid(int id)
        {
            return _context.Set<OverallService>().FirstOrDefault(x => x.OverallServiceId == id);
        }

    }
}
