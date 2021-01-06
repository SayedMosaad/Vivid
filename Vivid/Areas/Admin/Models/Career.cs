using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models
{
    public class Career
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Specification { get; set; }
        public string Responsibilities { get; set; }
    }
}
