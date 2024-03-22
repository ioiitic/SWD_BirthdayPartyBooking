using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.RequestDTO
{
    public class PlaceUpdateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
    }
}
