using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivid.Areas.Admin.Models;
using System.ComponentModel.DataAnnotations;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateProjectViewModel
    {
        [Required]
        [Display(Name ="Project Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Photographer { get; set; }
        
        [Required]
        public string Location { get; set; }

        [Required]
        public int Area { get; set; }
        public DateTime Date { get; set; }
        
        [Required]
        public string Team { get; set; }

        [Display(Name ="Cover Photo")]
        public IFormFile CoverFile { get; set; }

        [Required]
        public string Concepts { get; set; }

        [Display(Name = "Concepts Photo")]
        public IFormFile ConceptFile { get; set; }
        
        [Required]
        public string Planning { get; set; }

        [Display(Name = "Planning Photo")]
        public IFormFile PlanningFile { get; set; }
        
        [Required]
        public string Realizatiion { get; set; }

        [Display(Name = "Realization Photo")]
        public IFormFile RealizationFile { get; set; }
        
        [Required]
        [Display(Name = "Project Category")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
    public class EditProjectViewModel:CreateProjectViewModel
    {
        public int Id { get; set; }
        public string CoverImageUrl { get; set; }
        public string ConceptImageUrl { get; set; }
        public string PlanningImageUrl { get; set; }
        public string RealiztionImageUrl { get; set; }
    }
}
