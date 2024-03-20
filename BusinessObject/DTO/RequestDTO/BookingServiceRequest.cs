using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.RequestDTO
{
    public class BookingServiceRequest
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
