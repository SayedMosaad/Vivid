using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateSliderViewModel
    {
        [Required]
        public string Title { get; set; }
        public IFormFile File { get; set; }
    }
    public class EditSliderViewModel:CreateSliderViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
