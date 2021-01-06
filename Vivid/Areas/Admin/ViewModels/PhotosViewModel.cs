using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vivid.Areas.Admin.Models;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreatePhotosViewModel
    {
        public IFormFile File { get; set; }
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        public List<Project> Projects { get; set; }
    }

    public class EditPhotosViewModel:CreatePhotosViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }

}
