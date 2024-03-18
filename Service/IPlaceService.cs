using BusinessObject;
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
        Task<IEnumerable<Place>> GetAllPlaceByHostID(Guid Id);
        Place GetPlaceByPlaceID(Guid placeId);
        Task Remove(Guid Id);
    }
}
