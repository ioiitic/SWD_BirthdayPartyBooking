using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.ResponseDTO
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string PlaceName { get; set; }
        public string PlaceAddress { get; set; }
        public string HostName { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public int? TotalPrice { get; set; }
    }
}
