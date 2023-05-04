using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.BusinessObject
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Location { get; set; }
    }
}
