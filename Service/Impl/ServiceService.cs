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

        public ServiceResponse<object> Remove(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return new ServiceResponse<object>(false, "Id is null");
            }

            var checkpService = _repoWrapper.Service.GetServiceByServiceID(Id);
            
            if (checkpService == null)
            {
                return new ServiceResponse<object>(false, "Invalid data");
            }

            _repoWrapper.Service.Remove(Id);

            return new ServiceResponse<object>(true, "Delete Successfully.");
        }
        public ServiceResponse<object> UpdateService(ServiceResponseDTO service)
        {
            if (service.Id == Guid.Empty || service == null)
            {
                return new ServiceResponse<object>(false, "Invalid data");
            }

            var checkservice = _repoWrapper.Service.GetServiceByServiceID(service.Id);

            if (checkservice == null)
            {
                return new ServiceResponse<object>(false, "Not found");
            }
            checkservice = _mapper.Map(service, checkservice);
            _repoWrapper.Service.Update(checkservice);
            return new ServiceResponse<object>(true, "Update successfully.");
        }
    }
}
