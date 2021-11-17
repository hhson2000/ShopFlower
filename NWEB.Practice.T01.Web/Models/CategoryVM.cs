using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Order { get; set; }
        public string Note { get; set; }
    }
}
