using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Services.Impl;
using BusinessObject.DTO.ResponseDTO;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.RequestDTO;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("api/")]
    public class PlaceController : ControllerBase
    {
        private IServiceWrapper _service;

        public PlaceController(IServiceWrapper service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetPlace(Guid Id)
        {

            var places = _service.Place.GetAllPlaceByHostID(Id);
            if (places.Success == false)
                return BadRequest(places);
            if (!ModelState.IsValid)
                return BadRequest(new ServiceResponse<object>(false, "Moi"));

            return Ok(places);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePlace([FromBody] PlaceCreateDTO place)
        {
            try
            {
                if (place == null || place.HostId == Guid.Empty)
                {
                    return BadRequest(new ServiceResponse<object>(false, "Id Or Object is null"));
                }

                if (!ModelState.IsValid)
                    return BadRequest(new ServiceResponse<object>(false));
                var newPlace = _service.Place.CreatePlace(place);

                return Ok(newPlace);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("[action]/{placeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePlace(Guid placeId, [FromBody] PlaceUpdateRequest placeUpdateRequest)
        {
            //if (place == null)
            //{
            //    return BadRequest(ModelState);
            //}
            //if (placeId != place.Id)
            //{
            //    return BadRequest(ModelState);
            //}
            var update = _service.Place.Update(placeId, placeUpdateRequest);

            if (update.Success == false)
            {
                return NotFound(update);
            }

            return Ok(update);

            //var checkplaces = _service.Place.GetPlaceByPlaceID(placeId);
            //if (checkplaces==null)
            //{
            //    return NotFound();
            //}
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //_service.Place.Update(place);
            //return Ok("Successfully updated");
        }

        [HttpDelete("[action]/{placeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePlace(Guid placeId)
        {
            if (placeId == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
            var checkplaces = _service.Place.GetPlaceByPlaceID(placeId);
            if (checkplaces==null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Place.Remove(placeId);
            return Ok("Successfully updated");
        }


    }
}
