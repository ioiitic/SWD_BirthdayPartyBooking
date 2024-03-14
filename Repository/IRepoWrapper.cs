using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepoWrapper
    {
        IAccountRepo Account { get;}
        IOrderRepo Order { get;}
        IOrderDetailRepo OrderDetail { get;}
        IPlaceRepo Place { get;}
        IServiceRepo Service { get;}
        IServiceTypeRepo ServiceType { get; }
        void Save();
        IBaseRepo<T> GetRepository<T>() where T : class;

    }
}
