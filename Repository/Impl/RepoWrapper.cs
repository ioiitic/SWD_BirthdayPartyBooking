using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class RepoWrapper : IRepoWrapper
    {
        private BirthdayPartyBookingContext _context;
        private IAccountRepo _accountRepo;
        private IOrderRepo _orderRepo;
        private IOrderDetailRepo _orderDetailRepo;
        private IPlaceRepo _placeRepo;
        private IServiceRepo _serviceRepo;
        private IServiceTypeRepo _serviceTypeRepo; 
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public RepoWrapper(
            BirthdayPartyBookingContext context,
            IAccountRepo accountRepo,
            IOrderRepo orderRepo,
            IOrderDetailRepo orderDetailRepo,
            IPlaceRepo placeRepo,
            IServiceRepo serviceRepo,
            IServiceTypeRepo serviceTypeRepo)
        {
            _context = context;
            _accountRepo = accountRepo;
            _orderRepo = orderRepo;
            _orderDetailRepo = orderDetailRepo;
            _placeRepo = placeRepo;
            _serviceRepo = serviceRepo;
            _serviceTypeRepo = serviceTypeRepo;
        }

        public IAccountRepo Account => _accountRepo;

        public IOrderRepo Order => _orderRepo;

        public IOrderDetailRepo OrderDetail => _orderDetailRepo;

        public IPlaceRepo Place => _placeRepo;

        public IServiceRepo Service => _serviceRepo;

        public IServiceTypeRepo ServiceType => _serviceTypeRepo;

        public IBaseRepo<T> GetRepository<T>() where T : class
        {
            Type repoType = typeof(T);

            _repositories[typeof(Account)] = _accountRepo;
            _repositories[typeof(Order)] = _orderRepo;
            _repositories[typeof(OrderDetail)] = _orderDetailRepo;
            _repositories[typeof(Place)] = _placeRepo;
            _repositories[typeof(Service)] = _serviceRepo;
            _repositories[typeof(ServiceType)] = _serviceTypeRepo;
            return (IBaseRepo<T>)_repositories[repoType];
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
