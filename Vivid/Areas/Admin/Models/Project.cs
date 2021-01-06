using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photographer { get; set; }
        public string Location { get; set; }
        public int Area { get; set; }
        public DateTime Date { get; set; }
        public string Team { get; set; }
        public string CoverPhoto { get; set; }
        public string Concepts { get; set; }
        public string ConceptPhoto { get; set; }
        public string Planning { get; set; }
        public string PlanningPhoto { get; set; }
        public string Realizatiion { get; set; }
        public string RealizationPhoto { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}
