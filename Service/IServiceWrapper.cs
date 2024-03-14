using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServiceWrapper
    {
        IAccountService Account { get; }
        IOrderService Order { get; }
        IOrderDetailService OrderDetail { get; }
        IPlaceService Place { get; }
        IServiceService Service { get; }
        IServiceTypeService ServiceType { get; }
    }
}
