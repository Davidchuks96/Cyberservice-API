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

        public async Task Create(OverallService newOverallService)
        {
            await _context.Set<OverallService>().AddAsync(newOverallService);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<OverallService> GetAllOverallService()
        {
            return _context.OverallServices.ToList();
        }

        public void Delete(OverallService newService)
        {
            {
                _context.Set<OverallService>().Remove(newService);
                _context.SaveChanges();
            }
        }
        public OverallService GetOverllServiceByid(int id)
        {
            return _context.OverallServices.FirstOrDefault(A => A.Overallservice.Id == id);
        }

    }
}
