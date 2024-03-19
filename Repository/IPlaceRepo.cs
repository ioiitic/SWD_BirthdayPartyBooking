using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IPlaceRepo : IBaseRepo<Place>
    {
        List<Place> GetAllPlace(Guid Id);
        IEnumerable<Place> GetAllPlaceByHostID(Guid Id);
        Place GetPlaceByPlaceID(Guid placeId);
        bool Remove(Guid Id);
        bool Save();
    }
}
