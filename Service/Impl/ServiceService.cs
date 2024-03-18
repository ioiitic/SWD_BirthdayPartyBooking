using BusinessObject;
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
        public IServiceRepo serviceRepo;
        public ServiceService(IRepoWrapper repoWrapper, IServiceRepo serviceRepo)
            : base(repoWrapper)
        {
            this.serviceRepo=serviceRepo;
        }

        public Task<List<Service>> GetAllServicesByHostID(string Id) => serviceRepo.GetAllServicesByHostID(Id);

        public List<ServiceType> GetAllServiceTypes() => serviceRepo.GetAllServiceTypes();

        public Task<IEnumerable<Object>> GetServiceByHostIDAndServiceType(Guid hostId, string serviceType) => serviceRepo.GetServiceByHostIDAndServiceType(hostId, serviceType);

        public Service GetServiceByServiceID(Guid Id) => serviceRepo.GetServiceByServiceID(Id);

        public Task<Service> GetServiceByServiceIDAndHostID(Guid Id, string HostID) => serviceRepo.GetServiceByServiceIDAndHostID(Id, HostID);

        public ServiceType GetServiceTypeByServiceTypeID(Guid Id) => serviceRepo.GetServiceTypeByServiceTypeID(Id);

        public Guid GetServiceTypeIdByServiceName(string serviceName) =>serviceRepo.GetServiceTypeIdByServiceName(serviceName);

        public List<Service> GetValidServices(Guid Id) => serviceRepo.GetValidServices(Id);

        public Task Remove(Guid Id) => serviceRepo.Remove(Id);
    }
}
