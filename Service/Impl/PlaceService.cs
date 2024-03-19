using AutoMapper;
using BusinessObject;
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

        public IEnumerable<Place> GetAllPlaceByHostID(Guid Id) => _repoWrapper.Place.GetAllPlaceByHostID(Id);

        public Place GetPlaceByPlaceID(Guid placeId) => _repoWrapper.Place.GetPlaceByPlaceID(placeId);

        public bool Remove(Guid Id) => _repoWrapper.Place.Remove(Id);
    }
}
