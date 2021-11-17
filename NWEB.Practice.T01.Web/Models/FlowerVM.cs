using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Models
{
    public class FlowerVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        [Required]
        public double Price { get; set; }
        public double SalesPrice { get; set; }
        [Required]
        public DateTime StoreDate { get; set; }
        [Required]
        public int StoreInventory { get; set; }
    }
}
