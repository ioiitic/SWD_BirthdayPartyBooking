using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class ServiceRepo : BaseRepo<Service>, IServiceRepo
    {     
        public ServiceRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
        public List<Service> GetValidServices(Guid Id)
        {
            List<Service> services = new List<Service>();
            try
            {
                services = base._context.Services.AsNoTracking().Where(p => p.HostId == Id && p.DeleteFlag == 0).Include(s => s.ServiceType).OrderBy(s => s.ServiceTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        public List<Service> GetAllServicesByHostID(string Id)
        {
            List<Service> services = new List<Service>();
            try
            {
                services = base._context.Services.AsNoTracking().Where(s => s.HostId.ToString() == Id && s.DeleteFlag == 0)
                .Include(s => s.Host)
                .Include(s => s.ServiceType).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        //public List<Service> GetAllServices()
        //{
        //    List<Service> services = new List<Service>();
        //    try
        //    {
        //        services = _context.Services.AsNoTracking().Where(p => p.DeleteFlag == 0).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //    return services;
        //}
        public List<ServiceType> GetAllServiceTypes()
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();
            try
            {
                serviceTypes = base._context.ServiceTypes.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return serviceTypes;
        }
        public Service GetServiceByServiceID(Guid Id)
        {
            Service service = new Service();
            try
            {
                service = base._context.Services.AsNoTracking().FirstOrDefault(s => s.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return service;
        }

        public Service GetServiceByServiceIDAndHostID(Guid Id, string HostID)
        {
            Service service = new Service();
            try
            {
                service =  base._context.Services.AsNoTracking().Where(s => s.HostId.ToString() == HostID && s.DeleteFlag == 0)
                .Include(s => s.Host)
                .Include(s => s.ServiceType).FirstOrDefault(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return service;
        }

        public IEnumerable<Object> GetServiceByHostIDAndServiceType(Guid hostId, string serviceType)
        {
            try
            {
                return  _context.Services.Where(s => s.HostId == hostId && s.DeleteFlag == 0 && s.ServiceType.Name == serviceType)
                                                .Select(s => new
                                                {
                                                    s.Id,
                                                    s.Name,
                                                    s.Description,
                                                    s.Price
                                                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Guid GetServiceTypeIdByServiceName(string serviceName)
        {
            try
            {
                var serviceType = _context.ServiceTypes.AsNoTracking().FirstOrDefault(s => s.Name.ToLower() == serviceName.ToLower());
                return serviceType.Id;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ServiceType GetServiceTypeByServiceTypeID(Guid Id)
        {
            ServiceType serviceType = new ServiceType();
            try
            {
                serviceType = _context.ServiceTypes.AsNoTracking().FirstOrDefault(s => s.Id == Id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return serviceType;
        }

        //public async Task AddNew(Service service)
        //{
        //    try
        //    {
        //        _context.Services.Add(service);
        //        await _context.SaveChangesAsync();
        //        _context.Entry(service).State = EntityState.Detached;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
        //public async Task Update(Service service)
        //{
        //    try
        //    {
        //        Service _service = GetServiceByServiceID(service.Id);
        //        if (_service != null)
        //        {
        //            _context.Entry<Service>(service).State = EntityState.Modified;
        //            await _context.SaveChangesAsync();
        //            _context.Entry(service).State = EntityState.Detached;
        //        }
        //        else
        //        {
        //            throw new Exception("The service not found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public bool Remove(Guid Id)
        {
            try
            {
                Service _service = GetServiceByServiceID(Id);
                if (_service != null)
                {
                    _service.DeleteFlag = 1;
                    _context.Entry<Service>(_service).State = EntityState.Modified;                  
                }
                else
                {
                    throw new Exception("The service not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Save();
        }
        public bool Save()
        {
            var saved = base._context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
