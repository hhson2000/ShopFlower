using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string  CategoryName { get; set; }
        public int Order { get; set; }
        public string? Note { get; set; }
        public ICollection<Flower> Flowers { get; set; }

    }
}
