using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Entities
{
    public class Product : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Location { get; set; }
    }
}
