using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class PlaceRepo : BaseRepo<Place>,IPlaceRepo
    {
        public PlaceRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
        }
    }
}
