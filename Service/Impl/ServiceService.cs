using AutoMapper;
using BusinessObject;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;
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

        public Service GetServiceByServiceIDAndHostID(Guid Id, string serviceType) => _repoWrapper.Service.GetServiceByServiceIDAndHostID(Id, serviceType);

        public ServiceType GetServiceTypeByServiceTypeID(Guid Id) => _repoWrapper.Service.GetServiceTypeByServiceTypeID(Id);

        public Guid GetServiceTypeIdByServiceName(string serviceName) =>_repoWrapper.Service.GetServiceTypeIdByServiceName(serviceName);

        public List<Service> GetValidServices(Guid Id) => _repoWrapper.Service.GetValidServices(Id);
        public ServiceResponse<object> Create(ServiceCreateRequest serviceCreateRequest)
        {
            var newService = _mapper.Map<Service>(serviceCreateRequest);
            newService.DeleteFlag = 0;
            try
            {
                _repoWrapper.Service.Insert(newService);
            }
            catch
            {
                return new ServiceResponse<object>(false, "Something wrong when create");
            }

            return new ServiceResponse<object>(true, "Create successfully.");
        }

        public ServiceResponse<object> Update(Guid serviceId, ServiceUpdateRequest serviceUpdateRequest)
        {
            var checkService = _repoWrapper.Service.GetServiceByServiceID(serviceId);

            if (checkService == null)
            {
                return new ServiceResponse<object>(false, "Not found Service");
            }

            checkService = _mapper.Map(serviceUpdateRequest, checkService);

            _repoWrapper.Service.Update(checkService);
            return new ServiceResponse<object>(true, "Update successfully.");
        }

        public bool Remove(Guid Id) => _repoWrapper.Service.Remove(Id);
    }
}
