using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Data
{
    public class Flower
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string?  Color { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public double? SalesPrice { get; set; }
        public DateTime StoreDate { get; set; }
        public int StoreInventory { get; set; }

        public Category Categories { get; set; }

    }
}
