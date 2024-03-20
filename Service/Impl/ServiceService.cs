using AutoMapper;
using BusinessObject;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.ServiceDTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class ServiceService : BaseService<Service>, IServiceService
    {
        public ServiceService(IRepoWrapper repoWrapper, IMapper mapper)
            : base(repoWrapper, mapper)
        {
        }

        public List<Service> GetAllServicesByHostID(string Id) => _repoWrapper.Service.GetAllServicesByHostID(Id);

        public List<ServiceType> GetAllServiceTypes() => _repoWrapper.Service.GetAllServiceTypes();

        public ServiceResponse<IEnumerable<Object>> GetServiceByHostIDAndServiceType(Guid hostId, string serviceType)
        {
            var listservice =  _repoWrapper.Service.GetServiceByHostIDAndServiceType(hostId, serviceType);
            if (hostId == Guid.Empty || serviceType == null)
            {
                return new ServiceResponse<IEnumerable<Object>>(false, "Host ID is null");
            }
           
            return new ServiceResponse<IEnumerable<Object>>(listservice) ;
        }
        public Service GetServiceByServiceID(Guid Id) => _repoWrapper.Service.GetServiceByServiceID(Id);

        public Service GetServiceByServiceIDAndHostID(Guid Id, string HostID) => _repoWrapper.Service.GetServiceByServiceIDAndHostID(Id, HostID);

        public ServiceType GetServiceTypeByServiceTypeID(Guid Id) => _repoWrapper.Service.GetServiceTypeByServiceTypeID(Id);

        public Guid GetServiceTypeIdByServiceName(string serviceName) =>_repoWrapper.Service.GetServiceTypeIdByServiceName(serviceName);

        public List<Service> GetValidServices(Guid Id) => _repoWrapper.Service.GetValidServices(Id);

        public bool Remove(Guid Id) => _repoWrapper.Service.Remove(Id);
    }
}
