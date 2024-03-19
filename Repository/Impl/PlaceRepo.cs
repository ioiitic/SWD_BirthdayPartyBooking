using BusinessObject;
using Microsoft.EntityFrameworkCore;
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
        public List<Place> GetAllPlace(Guid Id)
        {
            List<Place> places = new List<Place>();
            try
            {
                places = _context.Places.AsNoTracking().Where(p => p.HostId == Id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return places;
        }
        public IEnumerable<Place> GetAllPlaceByHostID(Guid Id)
        {
            List<Place> places = new List<Place>();
            try
            {
                places =  _context.Places.AsNoTracking().Where(p => p.HostId == Id && p.DeleteFlag == 0)
                                                        .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return places;
        }

        //public async Task<Place> GetAllPlaceByHostIDAndPlaceID(string HostId, Guid placeId)
        //{
        //    Place places = new Place();
        //    try
        //    {
        //        places = await _context.Places.AsNoTracking().Where(p => p.HostId.ToString() == HostId)
        //        .Include(p => p.Host).FirstOrDefaultAsync(m => m.Id == placeId);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return places;
        //}

        public Place GetPlaceByPlaceID(Guid placeId)
        {
            Place places = new Place();
            try
            {
                places =  _context.Places.AsNoTracking().FirstOrDefault(m => m.Id == placeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return places;
        }

        public bool Remove(Guid Id)
        {
            try
            {
                Place _place = GetPlaceByPlaceID(Id);
                if (_place != null)
                {
                    _place.DeleteFlag = 1;
                    _context.Entry<Place>(_place).State = EntityState.Modified;                    
                }
                else
                {
                    throw new Exception("The place not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Save();
        }

        public bool Save()
        {
            var saved = base._context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
