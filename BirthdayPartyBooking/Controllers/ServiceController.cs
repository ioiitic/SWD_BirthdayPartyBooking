using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Services.Impl;
using System.Security.Principal;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.RequestDTO;

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
        public IActionResult GetServiceByType(Guid hostId, string serviceType)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<object>(false, "Moi"));

            var services = _service.Service.GetServiceByHostIDAndServiceType(hostId, serviceType);

            if (services.Success == false)
            {
                return NotFound(services);
            }

            return Ok(services);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateService([FromBody] ServiceCreateRequest serviceCreateRequest)
        {
            var create = _service.Service.Create(serviceCreateRequest);

            if (create.Success == false)
            {
                return Conflict(create);
            }

            return Created("auth/[action]", create);
            //if (service == null || hostID == Guid.Empty)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //service.DeleteFlag = 0;
            //service.HostId = hostID;
            //service.ServiceTypeId = serviceTypeId;
            //try
            //{
            //    _service.Service.Insert(service);
            //}
            //catch
            //{
            //    return BadRequest(ModelState);
            //}
            //return Ok("Successfully created");
        }

        [HttpPut("[action]/{serviceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateService(Guid serviceId, [FromBody] ServiceUpdateRequest serviceUpdateRequest)
        {

            var update = _service.Service.Update(serviceId, serviceUpdateRequest);

            if (update.Success == false)
            {
                return NotFound(update);
            }

            return Ok(update);
            //    if (service == null)
            //    {
            //        return BadRequest(ModelState);
            //    }
            //    if (serviceId != service.Id)
            //    {
            //        return BadRequest(ModelState);
            //    }
            //    var checkservices = _service.Service.GetServiceByServiceID(serviceId);
            //    if (checkservices==null)
            //    {
            //        return NotFound();
            //    }
            //    if (!ModelState.IsValid)
            //        return BadRequest(ModelState);

            //    _service.Service.Update(service);
            //    return Ok("Successfully updated");
        }

        [HttpDelete("[action]/{serviceId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteService(Guid serviceId)
        {
            if (serviceId == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
            var checkservices = _service.Service.GetServiceByServiceID(serviceId);
            if (checkservices==null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_service.Service.Remove(serviceId))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully removed.");
        }
    }
}
