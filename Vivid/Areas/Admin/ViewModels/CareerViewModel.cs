using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateCareerViewModel
    {
        [Required]
        [Display(Name ="Job Title")]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Specification { get; set; }

        [Required]
        public string Responsibilities { get; set; }
    }
    public class EditCareerViewModel:CreateCareerViewModel
    {
        public int Id { get; set; }
    }
}
