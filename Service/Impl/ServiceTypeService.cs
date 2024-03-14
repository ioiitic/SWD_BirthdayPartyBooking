using BusinessObject;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class ServiceTypeService : BaseService<ServiceType>, IServiceTypeService
    {
        public ServiceTypeService(IRepoWrapper repoWrapper)
            : base(repoWrapper)
        {
        }
    }
}
