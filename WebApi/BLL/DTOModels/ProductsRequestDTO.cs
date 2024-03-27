using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOModels
{
    public class ProductsRequestDTO
    {
        public string SortBy { get; set ; }
        public string FilterByName { get; set; }
        public string FilterByGroupName { get; set; }
        public int FilterByGroupId { get; set; }
        public bool IncludeInactive { get; set; }

    }
}
