using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string Image { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
