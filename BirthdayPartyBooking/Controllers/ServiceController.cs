using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController
    {
        private IServiceWrapper _service;
        private IServiceService _serviceService;

        public ServiceController(IServiceWrapper service, IServiceService serviceService)
        {
            _service = service;
            _serviceService=serviceService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Service> GetAllservices()
        {
            var services = _service.Service.GetAll();

            return services;
        }

        [HttpGet("[action]")]
        public IEnumerable<Service> GetAllServiceIncludeChildren(string[] children)
        {
            var services = _service.Service.GetAll(children);

            return services;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<service> GetAllservice([FromQuery] int deleteFlag)
        //{
        //    var services = _service.service.GetAll(a => a.DeleteFlag == deleteFlag);

        //    return services;
        //}

        [HttpGet("[action]")]
        public List<Service> GetValidServices(Guid Id)
        {
            var services = _serviceService.GetValidServices(Id);

            return services;
        }

        [HttpGet("[action]")]
        public async Task<List<Service>> GetAllServicesByHostID(string Id)
        {
           return await _serviceService.GetAllServicesByHostID(Id);
                      
        }

        [HttpGet("[action]")]
        public List<ServiceType> GetAllServiceTypes()
        {
            var services = _serviceService.GetAllServiceTypes();

            return services;
        }

        [HttpGet("[action]")]
        public async Task<Service> GetServiceByServiceIDAndHostID(Guid Id, string HostID)
        {
            return await _serviceService.GetServiceByServiceIDAndHostID(Id, HostID);
        }

        [HttpGet("[action]")]
        public ServiceType GetServiceTypeByServiceTypeID(Guid Id)
        {
           return _serviceService.GetServiceTypeByServiceTypeID(Id);    
        }
        [HttpPut("[action]")]
        public void InsertService(Service service)
        {
            _service.Service.Insert(service);
        }
        [HttpPut("[action]")]
        public void Updateservice(Service service)
        {
            _service.Service.Update(service);
        }

        [HttpDelete("[action]")]
        public async Task Remove(Guid Id)
        {
            await _serviceService.Remove(Id);
        }
    }
}
