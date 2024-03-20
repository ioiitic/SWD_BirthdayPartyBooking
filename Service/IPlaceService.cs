using BusinessObject;
using BusinessObject.DTO.PlaceDTO;
using BusinessObject.DTO.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPlaceService : IBaseService<Place>
    {
        List<Place> GetAllPlace(Guid Id);
        ServiceResponse<IEnumerable<object>> GetAllPlaceByHostID(Guid Id);
        Place GetPlaceByPlaceID(Guid placeId);
        ServiceResponse<object> CreatePlace(PlaceCreateDTO place);
        bool Remove(Guid Id);
    }
}
