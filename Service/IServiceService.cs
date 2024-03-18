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
        Task<IEnumerable<Object>> GetServiceByHostIDAndServiceType(Guid hostId, string serviceType);
        Guid GetServiceTypeIdByServiceName(string serviceName);
        Service GetServiceByServiceID(Guid Id);
        Task Remove(Guid Id);
    }
}
