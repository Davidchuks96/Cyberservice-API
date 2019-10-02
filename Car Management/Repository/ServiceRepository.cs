using Car_Management.Data;
using Car_Management.Model;
using Car_Management.ViewModel;
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

        public OverallService Create(OverallServiceViewModel viewModel)
        {
            return _context.Set<OverallService>().SingleOrDefault(b => b.OverallServiceId == viewModel.OverallServiceId);
        }

        public void Delete(Service newService)
        {
            {
                _context.Set<Service>().Remove(newService);
                _context.SaveChanges();
            }
        }
        public Service GetByid(int? id)
        {
            return _context.Services.FirstOrDefault(service => service.Id == id);
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

        public OverallService GetOverallServiceById(int OverallServiceId)
        {
            return _context.Overall.SingleOrDefault<OverallService>(service => service.OverallServiceId == OverallServiceId);
        }

        public void Update( Service newService)
        {
            _context.Set<Service>().Update(newService);
            _context.SaveChanges();
        }
        public void Add(Service service)
        {
            _context.Set<Service>().AddAsync(service);
            _context.SaveChanges();
        }

        public Service GetServiceById(int id)
        {
            var query = _context.Set<Service>().Where(x => x.Id == id).FirstOrDefault();
            return query;
        }
    }
}
    
