using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.ResponseDTO
{
    public class OrderDetailResponse
    {
        public string ServiceName { get; set; }
        public string ServiceType { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
    }
}
