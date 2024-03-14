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
        public ServiceService(IRepoWrapper repoWrapper)
            : base(repoWrapper)
        {
        }
    }
}
