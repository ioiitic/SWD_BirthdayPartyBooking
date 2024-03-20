using BusinessObject.DTO.PlaceDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.RequestDTO
{
    public class BookingRequest
    {
        public PlaceView place {  get; set; }
        public List<BookingServiceRequest> serviceRequests { get; set; }
    }
}
