using BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Services.Impl;

namespace BirthdayPartyBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private IServiceWrapper _service;
        private IPlaceService _placeService;

        public PlaceController(IServiceWrapper service, IPlaceService placeService)
        {
            _service = service;
            _placeService = placeService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Place))]
        [ProducesResponseType(400)]
        public IActionResult GetPlace(Guid Id)
        {

            var places = _placeService.GetAllPlaceByHostID(Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(places);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePlace(Guid hostID, [FromBody] Place place)
        {
            if (place == null || hostID == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            place.DeleteFlag = 0;
            place.HostId = hostID;
            try
            {
                _service.Place.Insert(place);
            }
            catch
            {
                return BadRequest(ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("[action]/{placeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePlace(Guid placeId, [FromBody] Place place)
        {
            if (place == null)
            {
                return BadRequest(ModelState);
            }
            if (placeId != place.Id)
            {
                return BadRequest(ModelState);
            }
            var checkplaces = _placeService.GetPlaceByPlaceID(placeId);
            if (checkplaces==null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Place.Update(place);
            return Ok("Successfully updated");
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
            var checkplaces = _placeService.GetPlaceByPlaceID(placeId);
            if (checkplaces==null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _placeService.Remove(placeId);
            return Ok("Successfully updated");
        }


    }
}
