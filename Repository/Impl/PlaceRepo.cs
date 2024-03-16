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
        private BirthdayPartyBookingContext _context;
        public PlaceRepo(BirthdayPartyBookingContext context)
            : base(context)
        {
            _context = context;
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
        public async Task<List<Place>> GetAllPlaceByHostID(string Id)
        {
            List<Place> places = new List<Place>();
            try
            {
                places = await _context.Places.AsNoTracking().Where(p => p.HostId.ToString() == Id && p.DeleteFlag == 0)
                                          .Include(p => p.Host)
                                          .ToListAsync();
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
                places =  _context.Places.AsNoTracking().Include(p => p.Host).FirstOrDefault(m => m.Id == placeId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return places;
        }

        public async Task Remove(Guid Id)
        {
            try
            {
                Place _place = GetPlaceByPlaceID(Id);
                if (_place != null)
                {
                    _place.DeleteFlag = 1;
                    _context.Entry<Place>(_place).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
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
        }
    }
}
