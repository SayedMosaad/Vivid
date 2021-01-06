using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateTeamViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        [Display(Name ="Biography")]
        public string Bio { get; set; }
        [Display(Name = "Profile Image")]
        public IFormFile File { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
    }

    public class EditTeamViewModel:CreateTeamViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

    }
}
