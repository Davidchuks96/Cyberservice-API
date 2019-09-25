using Car_Management.Data;
using Car_Management.Model;
using Car_Management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Repository
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
             _context.SaveChangesAsync();
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
            return _context.Overall.FirstOrDefault(service => service.OverallId == id);
        }

    }
}
