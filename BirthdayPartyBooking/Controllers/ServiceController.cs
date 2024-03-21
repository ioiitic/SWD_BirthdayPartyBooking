using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Services.Impl;
using System.Security.Principal;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.ServiceDTO;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ServiceController : ControllerBase
    {
        private IServiceWrapper _service;

        public ServiceController(IServiceWrapper service, IServiceService serviceService)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetServiceByType(Guid hostId, string ServiceType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new ServiceResponse<object>(false, "Moi"));

                var services = _service.Service.GetServiceByHostIDAndServiceType(hostId, ServiceType);

                if (services.Success == false)
                {
                    return NotFound(services);
                }

                return Ok(services);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateService(Guid hostID, Guid serviceTypeId, [FromBody] Service service)
        {
            if (service == null || hostID == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.DeleteFlag = 0;
            service.HostId = hostID;
            service.ServiceTypeId = serviceTypeId;
            try
            {
                _service.Service.Insert(service);
            }
            catch
            {
                return BadRequest(ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateService([FromBody] ServiceResponseDTO service)
        {
            try
            {
                var update = _service.Service.UpdateService(service);
                if (update.Success == false)
                {
                    return BadRequest(update);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ServiceResponse<object>(false));
                }

                return Ok(update);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("[action]/{serviceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteService(Guid serviceId)
        {
            try
            {
                var delete = _service.Service.Remove(serviceId);

                if (delete.Success == false)
                {
                    return BadRequest(delete);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(new ServiceResponse<object>(false));
                }

                return Ok(delete);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
