using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
