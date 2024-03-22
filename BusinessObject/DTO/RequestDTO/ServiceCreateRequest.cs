using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.RequestDTO
{
    public class ServiceCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int? Price { get; set; }
        public Guid? ServiceTypeId { get; set; }
        public Guid? HostId { get; set; }
    }
}
