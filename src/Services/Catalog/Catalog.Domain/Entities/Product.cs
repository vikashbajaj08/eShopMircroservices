using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public decimal UnitPrice { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public int CategoryId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
