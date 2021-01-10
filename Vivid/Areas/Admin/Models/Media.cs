using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models
{
    public class Media
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int MediaCategoryId { get; set; }
        public MediaCategory MediaCategory { get; set; }
    }
}
