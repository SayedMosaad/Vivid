using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vivid.Areas.Admin.Models;

namespace Vivid.Areas.Admin.ViewModels
{
    public class CreateMediaViewModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name="Media Image")]
        public IFormFile File { get; set; }

        [Required]
        [Display(Name = "Media Category")]
        public int CategoryId { get; set; }
        public List<MediaCategory> Categories { get; set; }
    }
    public class EditMediaViewModel:CreateMediaViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
    }
}
