using Car_Management.Data;
using Car_Management.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Management.Repository
{
    public class ServiceRepository:IService
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void  Create(Service newService)
        {
            _context.Set<Service>().AddAsync(newService);
            _context.SaveChangesAsync();
        }

        public void Delete(int? id, Service newService)
        {
            {
                var entity = _context.Set<Service>().Find(id);
                _context.Set<Service>().Remove(entity);
                _context.SaveChanges();
            }
        }
        public Service GetBy(int? id)
        {
            return _context.Services.FirstOrDefault(service => service.ServiceId == id);
        }

        public IEnumerable<Service> GetAll()
        {
            return _context.Services.ToList();
        }

        public IEnumerable<Service> GetByName(string name)
        {
            return _context.Services.Where(a => a.Name == name);
        }

        public IEnumerable<Service> GetByDescription(string description)
        {
            return _context.Services.Where(a => a.Description == description);
        }

        public IEnumerable<Service> GetBySerialNo(string serialno)
        {
            return _context.Services.Where(a => a.SerialNo == serialno);
        }

        //public Service GetByDate(DateTime Datetime);


        public void Update(int? id, Service newService)
        {
            var entity = _context.Set<Service>().Find(id);
            _context.Set<Service>().Update(entity);
            _context.SaveChanges();
        }
    }
}
    
