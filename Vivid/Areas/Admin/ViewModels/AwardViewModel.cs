using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateAwardViewModel
    {
        [Required]
        public string Name { get; set; }
        [Display(Name ="Award Image")]
        public IFormFile File { get; set; }
    }

    public class EditAwardViewModel:CreateAwardViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
