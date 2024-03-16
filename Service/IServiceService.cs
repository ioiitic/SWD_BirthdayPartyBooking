using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServiceService : IBaseService<Service>
    {
        List<Service> GetValidServices(Guid Id);
        Task<List<Service>> GetAllServicesByHostID(string Id);
        List<ServiceType> GetAllServiceTypes();
        Task<Service> GetServiceByServiceIDAndHostID(Guid Id, string HostID);
        ServiceType GetServiceTypeByServiceTypeID(Guid Id);
        Task Remove(Guid Id);
    }
}
