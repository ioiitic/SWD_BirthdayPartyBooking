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
    public class PlaceController
    {
        private IServiceWrapper _service;
        private IPlaceService _placeService;

        public PlaceController(IServiceWrapper service, IPlaceService placeService)
        {
            _service = service;
            _placeService = placeService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Place> GetAllPlace(Guid id)
        {
            var places = _placeService.GetAllPlace(id);

            return places;
        }

        [HttpGet("[action]")]
        public IEnumerable<Place> GetAllPlaceIncludeChildren(string[] children)
        {
            var places = _service.Place.GetAll(children);

            return places;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<Account> GetAllAccount([FromQuery] int deleteFlag)
        //{
        //    var accounts = _service.Account.GetAll(a => a.DeleteFlag == deleteFlag);

        //    return accounts;
        //}

        [HttpGet("[action]")]
        public async Task<List<Place>> GetAllPlaceByHostID(string Id)
        {
            var places = await _placeService.GetAllPlaceByHostID(Id);

            return places;
        }

        [HttpGet("[action]")]
        public Place GetPlaceByPlaceID(Guid id)
        {
            var place = _service.Place.GetById(id); 

            return place;
        }

        [HttpPut("[action]")]
        public void InsertPlace(Place place)
        {
            _service.Place.Insert(place);
        }

        [HttpPut("[action]")]
        public void Updateplace(Place place)
        {
            _service.Place.Update(place);
        }

        [HttpDelete("[action]")]
        public void DeletePlace(Guid id)
        {
            _placeService.Remove(id);
        }
    }
}
