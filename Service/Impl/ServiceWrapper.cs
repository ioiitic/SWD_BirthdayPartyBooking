using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IAccountService _accountService;
        private IOrderService _orderService;
        private IOrderDetailService _orderDetailService;
        private IPlaceService _placeService;
        private IServiceService _serviceService;
        private IServiceTypeService _serviceTypeService;

        public ServiceWrapper(
            BirthdayPartyBookingContext context,
            IAccountService accountService,
            IOrderService orderService,
            IOrderDetailService orderDetailService,
            IPlaceService placeService,
            IServiceService serviceService,
            IServiceTypeService serviceTypeService)
        {
            _accountService = accountService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _placeService = placeService;
            _serviceService = serviceService;
            _serviceTypeService = serviceTypeService;
        }

        public IAccountService Account => _accountService;

        public IOrderService Order => _orderService;

        public IOrderDetailService OrderDetail => _orderDetailService;

        public IPlaceService Place => _placeService;

        public IServiceService Service => _serviceService;

        public IServiceTypeService ServiceType => _serviceTypeService;
    }
}
