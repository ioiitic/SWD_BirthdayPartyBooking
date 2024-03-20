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

        public bool Remove(Guid Id) => _repoWrapper.Place.Remove(Id);
    }
}
