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
        public PlaceService(IRepoWrapper repoWrapper)
            : base(repoWrapper)
        {
        }
    }
}
