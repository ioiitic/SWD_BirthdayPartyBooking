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
        public BirthdayPartyBookingContext _context;
        public ServiceRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
            _context = context;
        }
        public List<Service> GetValidServices(Guid Id)
        {
            List<Service> services = new List<Service>();
            try
            {
                services = _context.Services.AsNoTracking().Where(p => p.HostId == Id && p.DeleteFlag == 0).Include(s => s.ServiceType).OrderBy(s => s.ServiceTypeId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        public async Task<List<Service>> GetAllServicesByHostID(string Id)
        {
            List<Service> services = new List<Service>();
            try
            {
                services = await _context.Services.AsNoTracking().Where(s => s.HostId.ToString() == Id && s.DeleteFlag == 0)
                .Include(s => s.Host)
                .Include(s => s.ServiceType).ToListAsync();
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
                serviceTypes = _context.ServiceTypes.AsNoTracking().ToList();
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
                service = _context.Services.AsNoTracking().FirstOrDefault(s => s.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return service;
        }

        public async Task<Service> GetServiceByServiceIDAndHostID(Guid Id, string HostID)
        {
            Service service = new Service();
            try
            {
                service = await _context.Services.AsNoTracking().Where(s => s.HostId.ToString() == HostID && s.DeleteFlag == 0)
                .Include(s => s.Host)
                .Include(s => s.ServiceType).FirstOrDefaultAsync(m => m.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return service;
        }

        public async Task<IEnumerable<Object>> GetServiceByHostIDAndServiceType(Guid hostId, string serviceTypeId)
        {
            try
            {
                return await _context.Services.Where(s => s.HostId == hostId && s.DeleteFlag == 0 && s.ServiceType.Name == serviceTypeId)
                                                .Select(s => new
                                                {
                                                    s.Id,
                                                    s.Name,
                                                    s.Description,
                                                    s.Price
                                                }).ToListAsync();
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

        public async Task Remove(Guid Id)
        {
            try
            {
                Service _service = GetServiceByServiceID(Id);
                if (_service != null)
                {
                    _service.DeleteFlag = 1;
                    _context.Entry<Service>(_service).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
        }
    }
}
