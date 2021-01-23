using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name ="Category Image")]
        public IFormFile File { get; set; }
    }
    public class EditCategoryViewModel:CreateCategoryViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
