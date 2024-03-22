using BusinessObject;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.ServiceDTO;
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
        List<Service> GetAllServicesByHostID(string Id);
        List<ServiceType> GetAllServiceTypes();
        ServiceResponse<object> Create(ServiceCreateRequest serviceCreateRequest);
        ServiceResponse<object> Update(Guid serviceId, ServiceUpdateRequest serviceUpdateRequest);
        Service GetServiceByServiceIDAndHostID(Guid Id, string HostID);
        ServiceType GetServiceTypeByServiceTypeID(Guid Id);
        ServiceResponse<IEnumerable<Object>> GetServiceByHostIDAndServiceType(Guid hostId, string serviceType);
        Guid GetServiceTypeIdByServiceName(string serviceName);
        Service GetServiceByServiceID(Guid Id);
        bool Remove(Guid Id);
    }
}
