using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IServiceRepo : IBaseRepo<Service>
    {
        List<Service> GetValidServices(Guid Id);
        List<Service> GetAllServicesByHostID(string Id);
        List<ServiceType> GetAllServiceTypes();
        Service GetServiceByServiceIDAndHostID(Guid Id, string HostID);
        ServiceType GetServiceTypeByServiceTypeID(Guid Id);
        IEnumerable<Object> GetServiceByHostIDAndServiceType(Guid hostId, string serviceType);
        Guid GetServiceTypeIdByServiceName(string serviceName);
        Service GetServiceByServiceID(Guid Id);
        bool Remove(Guid Id);
        bool Save();
    }
}
