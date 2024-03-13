using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public decimal Value { get; set; }
        public bool IsPaid { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
