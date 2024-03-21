using AutoMapper;
using BusinessObject;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.ResponseDTO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class PlaceService : BaseService<Place>, IPlaceService
    {
        public PlaceService(IRepoWrapper repoWrapper, IMapper mapper) : base(repoWrapper, mapper)
        {
        }

        public ServiceResponse<object> CreatePlace(PlaceCreateDTO place)
        {
            var newPlace = _mapper.Map<Place>(place);
            newPlace.DeleteFlag = 0;
            try
            {
                _repoWrapper.Place.Insert(newPlace);
            }
            catch
            {
                return new ServiceResponse<object>(false, "Something wrong when create");
            }

            return new ServiceResponse<object>(true, "Create successfully.");
        }

        public List<Place> GetAllPlace(Guid Id) => _repoWrapper.Place.GetAllPlace(Id);

        public ServiceResponse<IEnumerable<object>> GetAllPlaceByHostID(Guid Id)
        {
            if(Id == Guid.Empty) 
                return new ServiceResponse<IEnumerable<object>>(false, "ID is null");  
            var places = _repoWrapper.Place.GetAllPlaceByHostID(Id);
            List<PlaceView> listPlace = new List<PlaceView>();
            foreach (var place in places)
            {
                var item = _mapper.Map<PlaceView>(place);
                listPlace.Add(item);
            }
            return new ServiceResponse<IEnumerable<object>>(listPlace);
        }
        public Place GetPlaceByPlaceID(Guid placeId) => _repoWrapper.Place.GetPlaceByPlaceID(placeId);

        public ServiceResponse<object> Remove(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return new ServiceResponse<object>(false, "Id is null");
            }
            var checkplaces = _repoWrapper.Place.GetPlaceByPlaceID(Id);
            if (checkplaces==null)
            {
                return new ServiceResponse<object>(false, "Invalid data");
            }

            _repoWrapper.Place.Remove(Id);
            return new ServiceResponse<object>(true, "Delete Successfully.");
        }
        public ServiceResponse<object> UpdatePlace(PlaceView place)
        {
            if (place.Id == Guid.Empty || place == null)
            {
                return new ServiceResponse<object>(false, "Invalid data");
            }

            var checkplaces = _repoWrapper.Place.GetPlaceByPlaceID(place.Id);

            if (checkplaces == null)
            {
                return new ServiceResponse<object>(false, "Not found");
            }
            checkplaces = _mapper.Map(place, checkplaces);
            _repoWrapper.Place.Update(checkplaces);
            return new ServiceResponse<object>(true, "Update successfully.");
        }
    }
}
