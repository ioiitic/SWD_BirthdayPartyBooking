﻿using BusinessObject;
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
        private IPlaceRepo placeRepo;
        public PlaceService(IRepoWrapper repoWrapper, IPlaceRepo placeRepo)
            : base(repoWrapper)
        {
            this.placeRepo=placeRepo;
        }

        public List<Place> GetAllPlace(Guid Id) => placeRepo.GetAllPlace(Id);

        public Task<IEnumerable<Place>> GetAllPlaceByHostID(Guid Id) => placeRepo.GetAllPlaceByHostID(Id);

        public Place GetPlaceByPlaceID(Guid placeId) => placeRepo.GetPlaceByPlaceID(placeId);

        public Task Remove(Guid Id) => placeRepo.Remove(Id);
    }
}
