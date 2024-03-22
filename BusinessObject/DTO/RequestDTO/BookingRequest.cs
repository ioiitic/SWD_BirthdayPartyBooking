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
        public Guid GuestId { get; set; }
        public Guid HostId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int TotalPrice { get; set; }
        public Guid PlaceId {  get; set; }
        public List<BookingServiceRequest> ServiceRequests { get; set; }
    }
}
